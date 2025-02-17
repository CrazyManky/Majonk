using UnityEngine;
using UnityEngine.Device;

namespace _Project.Screpts.Screens
{
    public class MenuScreen : BaseScreen
    {
        [SerializeField] private FactsScreen _factsScreen;

        public void OpenSetting()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowSettingsScreen();
        }

        public void ShowGameScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowGameScreen();
        }

        public void ShowFactsScreen()
        {
            Instantiate(_factsScreen, transform);
        }


        public void AppOut()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}