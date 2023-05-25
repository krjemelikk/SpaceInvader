using System.Collections;
using UnityEngine;

namespace Source.Infrastructure.Services
{
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] private CanvasGroup _screen;

        public void Show()
        {
            gameObject.SetActive(true);
            _screen.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            while (_screen.alpha > 0)
            {
                _screen.alpha -= 0.02f;
                yield return new WaitForSeconds(0.02f);
            }

            gameObject.SetActive(false);
        }
    }
}