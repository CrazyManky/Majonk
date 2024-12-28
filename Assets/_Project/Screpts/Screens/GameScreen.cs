using System.Collections;
using _Project.Screpts.Instances;
using _Project.Screpts.ItemsCounter;
using _Project.Screpts.TimerLevel;
using UnityEngine;

namespace _Project.Screpts.Screens
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private PauseScreen _pauseScreen;
        [SerializeField] private LevelCompliedScreen _levelCompliedScreen;
        [SerializeField] private Counter _counter;
        [SerializeField] private HinsScreen _hinsScreen;
        [SerializeField] private Timer _timer;
        [SerializeField] private BoneInstance _bonesInstanceOne;
        [SerializeField] private BoneInstance _bonesInstanceTwo;


        public void OnEnable()
        {
            _counter.CountEnd += ShowLevelComplited;
            _timer.OnTimerEnd += ShowGameEndScreen;
        }
        
        public override void Init()
        {
            base.Init();
            _bonesInstanceTwo.InstanceItemsAsync();
            _bonesInstanceOne.InstanceItemsAsync();
            _timer.Init();
            StartCoroutine(DisableGroyp());
        }
        
        private IEnumerator DisableGroyp()
        {
            var waitForSecondsRealTime = new WaitForSecondsRealtime(0.3f);
            yield return waitForSecondsRealTime;
            _bonesInstanceOne.FinalizeInstanceCreation();
            _bonesInstanceTwo.FinalizeInstanceCreation();
        }


        public void ShowHinsScreen()
        {
            AudioManager.PlayButtonClick();
            var instanceScreen = Instantiate(_hinsScreen, transform);
        }

        public void ShowGameEndScreen()
        {
            var instanceScreen = Instantiate(_gameOverScreen, transform);
            instanceScreen.Constructor();
        }

        public void ShowPauseScreen()
        {
            AudioManager.PlayButtonClick();
            var instanceScreen = Instantiate(_pauseScreen, transform);
            instanceScreen.Constructor(_timer);
        }

        public void ShowLevelComplited()
        {
            var instanceScreen = Instantiate(_levelCompliedScreen, transform);
            instanceScreen.Init();
        }

        private void OnDisable()
        {
            _counter.CountEnd -= ShowLevelComplited;
            _timer.OnTimerEnd += ShowGameEndScreen;
        }
    }
}