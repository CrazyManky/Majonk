using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Screpts.Load
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _text;

        public void Start() => LoadNextScene();

        private async void LoadNextScene()
        {
            var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            var taskLoad = SceneManager.LoadSceneAsync(nextSceneIndex);
            taskLoad.allowSceneActivation = false;

            // Цикл для обновления прогресса загрузки
            while (taskLoad.progress < 0.9f)
            {
                UpdateProgress(taskLoad.progress);
                await UniTask.Yield(); // Ждём следующий кадр
            }

            // Прогресс почти завершён
            UpdateProgress(1f);

            // Активируем сцену
            taskLoad.allowSceneActivation = true;
        }

        private void UpdateProgress(float progress)
        {
            // Масштабируем прогресс от 0 до 1
            _slider.value = progress;
            _text.text = $"{Mathf.RoundToInt(progress * 100)}%";
        }
    }
}