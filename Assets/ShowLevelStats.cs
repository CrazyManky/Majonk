using TMPro;
using UnityEngine;

public class ShowLevelStats : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private TextMeshProUGUI _textLevel;

    public void Start()
    {
        _textLevel.text = $"{_levelConfig.LevelIndex + 1}";
    }
}