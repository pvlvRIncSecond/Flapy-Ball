using System;

namespace CodeBase.Infrastructure.Scenes
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action onLoad = null);
    }
}