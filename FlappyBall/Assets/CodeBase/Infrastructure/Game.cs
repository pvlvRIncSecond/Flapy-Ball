﻿using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.Services.Locator;
using CodeBase.Infrastructure.StateMachine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ISceneLoader sceneLoader, ServiceLocator serviceLocator, ICoroutineRunner coroutineRunner) =>
            StateMachine = new GameStateMachine(sceneLoader, serviceLocator, coroutineRunner);
    }
}