﻿using _Project.Screpts.ScreptsSO;
using Project.Screpts.Screens;
using Services;
using UnityEngine;

namespace _Project.Screpts.Screens
{
    public abstract class BaseScreen : MonoBehaviour
    {
        protected DialogLauncher Dialog;
        protected AudioManager AudioManager;

        public virtual void Init()
        {
            Dialog = ServiceLocator.Instance.GetService<DialogLauncher>();
            AudioManager = ServiceLocator.Instance.GetService<AudioManager>();
        }

        public virtual void Сlose() => Destroy(gameObject);
    }
}