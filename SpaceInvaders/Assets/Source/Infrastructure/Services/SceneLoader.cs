using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Source.Infrastructure.Services
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string sceneName, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(Load(sceneName, onLoaded));

        private IEnumerator Load(string sceneName, Action onLoaded = null)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}