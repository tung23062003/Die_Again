using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistantSingleton<GameManager>
{
    [SerializeField] private LevelDataSO levelData;
    [SerializeField] private Vector3 mapPosition = new Vector3(0, -2, 0);
    [HideInInspector] public int loadingLevel;

    public int unlockedLevel;
    protected override void Awake()
    {
        base.Awake();
        GameEvent.OnEndLevel.AddListener(OnEndLevel);

        unlockedLevel = PlayerPrefs.GetInt("Level", 1);
    }

    private void OnDestroy()
    {
        GameEvent.OnEndLevel.RemoveAllListeners();
    }

    private void OnEndLevel(EndLevelType endLevelType)
    {
        if (endLevelType == EndLevelType.Win)
        {
            unlockedLevel = PlayerPrefs.GetInt("Level", 1);
            if(loadingLevel >= unlockedLevel)
            {
                unlockedLevel += 1;
                PlayerPrefs.SetInt("Level", loadingLevel + 1);
            }
        }
    }

    public async void LoadLevel(bool isSpawnNextLevel = false, bool isRestartLevel = false)
    {
        GameEvent.OnStartLevel?.Invoke();

        if (isSpawnNextLevel)
        {
            if (IsMaxLevel())
            {
                LoadScene(GameConstants.MENU_SCENE, () => { DestroySingleton(); });
                return;
            }
            loadingLevel += 1;
            await ObjectPool.Instance.DespawnAll();
        }
        else if (isRestartLevel)
            await ObjectPool.Instance.DespawnAll();

        await Spawner.Instance.AddMap(levelData.GetMapByLevel(loadingLevel), mapPosition, Quaternion.identity);
        await Spawner.Instance.AddPlayer(Vector3.zero, Quaternion.identity);
        //Spawner.Instance.AddMap(levelData.GetMapByLevel(loadingLevel));
    }

    public void LoadScene(string sceneName, Action onComplete = null)
    {
        SceneManager.LoadSceneAsync(sceneName);

        if (sceneName == GameConstants.MAIN_SCENE)
            StartCoroutine(StartLoadLevel());

        onComplete?.Invoke();
    }

    public IEnumerator StartLoadLevel()
    {
        yield return new WaitForSeconds(0.5f);
        LoadLevel();
    }


    public bool IsMaxLevel()
    {
        return loadingLevel == levelData.GetLevelQuantity();
    }
}
