using _Project.Screpts.ScreptsSO;
using Project.Screpts.Screens;
using Services;
using UnityEngine;

namespace _Project.Screpts.Screens
{
    public class GameOverScreen : MonoBehaviour
    {
        private DialogLauncher _dialogLauncher;
        private AudioManager _audioManager;

        public void Constructor()
        {
            _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public void ShowMenuScreen()
        {
            _audioManager.PlayButtonClick();
            _dialogLauncher.ShowMenuScreen();
        }
    }
}