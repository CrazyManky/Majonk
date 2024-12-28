using UnityEngine;

namespace _Project.Screpts.Screens
{
    public class LevelCompliedScreen : BaseScreen
    {
        [SerializeField] private LevelConfig _levelConfig;

        public void ContinueLevel()
        {
            AudioManager.PlayButtonClick();
            _levelConfig.LevelIndexAdd();
            Dialog.ShowGameScreen();
        }

        public void ShowMenu()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }
    }
}