using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Locator;
using CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public GameStateMachine(ISceneLoader sceneLoader, ServiceLocator serviceLocator, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, serviceLocator, coroutineRunner),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, serviceLocator.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(this, serviceLocator.Single<IGameFactory>()),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();

            LogState<TState>();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> state = ChangeState<TState>();
            state.Enter(payload);
            
            LogState<TState>();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
        
        private void LogState<TState>() where TState : class, IExitableState =>
            Debug.Log($"Entered {typeof(TState).Name}");
    }
}