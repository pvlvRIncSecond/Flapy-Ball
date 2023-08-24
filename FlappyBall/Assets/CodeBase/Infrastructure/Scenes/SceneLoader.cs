using System;
using System.Collections;
using CodeBase.Components;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Scenes
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly Curtain _curtain;

        public SceneLoader(ICoroutineRunner coroutineRunner, Curtain curtain)
        {
            _coroutineRunner = coroutineRunner;
            _curtain = curtain;
        }

        public void Load(string sceneName, Action onLoad = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoad));    
        }

        private IEnumerator LoadScene(string sceneName, Action onLoad)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoad?.Invoke();
                yield break;
            }
            
            _curtain.Show();
            
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
                yield return null;
            
            onLoad?.Invoke();
            
            _curtain.Hide();
        }
    }
}