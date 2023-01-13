using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelStorage", menuName = "LevelData/LevelStorage", order = 9)]
public class LevelStorage : ScriptableObject
{
    [SerializeField] private string[] simpleLevels;
    [SerializeField] private string[] secretLevels;
    [SerializeField] private string[] uniqLevels;
    [SerializeField] private string[] deathLevels;
    [SerializeField] private List<string> completedLevels;
    private int simpleLevelIndex = 0;
    private string currentLevel;

    public int SimpleLevelIndex { get => simpleLevelIndex; }
    public string[] DeathLevels { get => deathLevels; }
    public string[] SecretLevels { get => secretLevels; }
    public string[] UniqLevels { get => uniqLevels; }


    public string GetFirstLevel()
    {
        if (simpleLevels.Length > 0)
        {
            currentLevel = simpleLevels[0];
            return currentLevel;
        }

        throw new System.Exception("You need watch your LevelStorage, first level cant be founded!");
    }

    public string GetNextLevel()
    {
        if (simpleLevels.Length > 0)
        {
            simpleLevelIndex++;
            currentLevel = simpleLevels[simpleLevelIndex];
            completedLevels.Add(currentLevel);
            return currentLevel;
        }
        throw new System.Exception("you dont have a next level in LevelStorage");
    }

    public string GetCurrentLevel()
    {
        if (currentLevel != null)
        {
            return currentLevel;
        }
        throw new System.Exception("Watch LevelStorage");
    }

    public bool SearchCompletedLevel(string level)
    {
        if (completedLevels.Contains(level))
        {
            return true;
        }
        throw new System.Exception("This level is not founded or completed");
    }

}
