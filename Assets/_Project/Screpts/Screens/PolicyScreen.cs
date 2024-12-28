using System;
using _Project.Screpts.ScreptsSO;
using Services;
using UnityEngine;

namespace _Project.Screpts.Screens
{
    public class PolicyScreen : MonoBehaviour
    {
        private AudioManager _audioManager;

        private void Awake()
        {
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public void CLose()
        {
            _audioManager.PlayButtonClick();
            Destroy(this.gameObject);
        }
    }
}