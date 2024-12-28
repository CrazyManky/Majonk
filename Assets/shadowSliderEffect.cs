using UnityEngine;
using UnityEngine.UI;


public class shadowSliderEffect : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _imageA;
    [SerializeField] private Image _imageB;

    private void Start()
    {
        UpdateImages(_slider.value);

        _slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        UpdateImages(value);
    }

    private void UpdateImages(float sliderValue)
    {
        _imageA.fillAmount = sliderValue;
        _imageB.fillAmount = 1f - sliderValue;
    }
}