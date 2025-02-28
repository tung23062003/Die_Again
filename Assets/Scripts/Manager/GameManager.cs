using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistantSingleton<GameManager>
{
    [SerializeField] private LevelDataSO levelData;
    [HideInInspector] public int loadingLevel;

    protected override void Awake()
    {
        base.Awake();

        GameEvent.OnWinLevel.AddListener(OnWinLevel);
    }

    private void OnDestroy()
    {
        GameEvent.OnWinLevel.RemoveAllListeners();
    }
    private void Start()
    {
        LoadLevel(1);
    }

    private void OnWinLevel()
    {

    }

    public void LoadLevel(int level)
    {
        Spawner.Instance.AddPlayer(Vector3.zero, Quaternion.identity);
        Spawner.Instance.AddMap(levelData.GetMapByLevel(2));
        //Spawner.Instance.AddMap(levelData.GetMapByLevel(loadingLevel));
    }

    public void LoadNextLevel()
    {
        LoadLevel(loadingLevel + 1);
    }
}
