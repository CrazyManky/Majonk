using _Project.Screpts.ScreptsSO;
using Services;
using UnityEngine;

namespace _Project.Screpts.Screens
{
    public class HinsScreen : MonoBehaviour
    {
        private AudioManager _audioManager;

        public void Awake()
        {
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public void CloseScreen()
        {
            _audioManager.PlayButtonClick();
            Destroy(gameObject);
        }
    }
}