using Source.Infrastructure.Services;
using Source.Infrastructure.StateMachine.States;

namespace Source.Infrastructure.StateMachine.GameStates
{
    public class LoadLevelState : IConfigurableState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingScreen _loadingScreen;

        public LoadLevelState(ISceneLoader sceneLoader, ILoadingScreen loadingScreen)
        {
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
        }

        public void Enter(string sceneName)
        {
            _loadingScreen.Show();
            _sceneLoader.LoadScene(sceneName);
        }


        public void Exit()
        {
            _loadingScreen.Hide();
        }
    }
}