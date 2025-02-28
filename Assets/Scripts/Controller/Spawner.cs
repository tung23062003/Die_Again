using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    [SerializeField] private GameObject playerPrefab;
    
    public void AddMap(GameObject map, Action onComplete = null)
    {
        Instantiate(map);
        onComplete?.Invoke();
    }

    public void AddPlayer(Vector3 postion, Quaternion rotation, Transform parent = null, Action onComplete = null)
    {
        var player = Instantiate(playerPrefab, postion, rotation, parent);
        GameEvent.OnAddPlayer?.Invoke(player.transform);
        onComplete?.Invoke();
    }
}
