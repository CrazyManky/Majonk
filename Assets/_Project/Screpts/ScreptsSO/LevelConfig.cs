using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _levelIndex;
    
    public int LevelIndex => _levelIndex;

    public void LevelIndexAdd()
    {
        _levelIndex++;
    }

    public void ResetLevelIndex()
    {
        _levelIndex = 0;
    }
}