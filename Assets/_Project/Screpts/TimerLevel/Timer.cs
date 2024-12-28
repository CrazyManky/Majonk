using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Screpts.TimerLevel
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private float remainingTime = 600f;
        public event Action OnTimerEnd;
        public void Init() => StartCoroutine(StartTimer());


        private IEnumerator StartTimer()
        {
            while (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

                if (_timerText != null)
                {
                    int minutes = Mathf.FloorToInt(remainingTime / 60);
                    int seconds = Mathf.FloorToInt(remainingTime % 60);

                    _timerText.text = $"{minutes:00}:{seconds:00}";
                }

                yield return null;
            }

            OnTimerEnd?.Invoke();
        }

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Continue()
        {
            Time.timeScale = 1;
        }
    }
}