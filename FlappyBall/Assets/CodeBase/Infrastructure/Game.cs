using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.StateMachine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ISceneLoader sceneLoader) => 
            StateMachine = new GameStateMachine(sceneLoader);
    }
}