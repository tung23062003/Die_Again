using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Data", menuName = "Data/Level Data", order = 1)]
public class LevelDataSO : ScriptableObject
{
    public List<LevelInfo> levels = new();

    public GameObject GetMapByLevel(int level)
    {
        return levels.Find(item => item.level == level).map;
    }

    public int GetLevelQuantity()
    {
        return levels.Count;
    }
}

[System.Serializable]
public class LevelInfo
{
    public int level;
    public GameObject map;
}
