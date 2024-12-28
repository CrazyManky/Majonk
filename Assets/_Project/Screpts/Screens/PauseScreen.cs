using _Project.Screpts.ScreptsSO;
using _Project.Screpts.TimerLevel;
using Project.Screpts.Screens;
using Services;
using UnityEngine;

namespace _Project.Screpts.Screens
{
    public class PauseScreen : MonoBehaviour
    {
        private DialogLauncher _dialogLauncher;
        private AudioManager _audioManager;
        private Timer _timer;

        public void Constructor(Timer timer)
        {
            _timer = timer;
            _timer.Pause();
            _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public void ContinueGame()
        {
            _audioManager.PlayButtonClick();
            _timer.Continue();
            Destroy(gameObject);
        }

        public void ShowMenuScreen()
        {
            _audioManager.PlayButtonClick();
            _timer.Continue();
            _dialogLauncher.ShowMenuScreen();
        }
    }
}