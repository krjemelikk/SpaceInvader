using Source.Infrastructure.Factories;
using Source.Infrastructure.Services.Score;
using Source.Infrastructure.Services.Screen;
using Source.UI.Factory;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.Installers.Local
{
    public class LocalServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            UIFactory();

            ScoreService();

            BulletFactory();

            GameFactory();

            ScreenBounds();
        }

        private void UIFactory() =>
            Container.BindInterfacesTo<UIFactory>().AsSingle();

        private void ScoreService() =>
            Container.BindInterfacesTo<ScoreService>().AsSingle();

        private void BulletFactory() =>
            Container.BindInterfacesTo<BulletFactory>().AsSingle();

        private void GameFactory() =>
            Container.BindInterfacesTo<GameFactory>().AsSingle();

        private void ScreenBounds() =>
            Container.BindInterfacesTo<ScreenBounds>().AsSingle().WithArguments(Camera.main);
    }
}