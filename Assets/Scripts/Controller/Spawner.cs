using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    [SerializeField] private GameObject playerPrefab;

    private GameObject map;

    public async Task AddMap(GameObject map, Vector3 postion, Quaternion rotation, Transform parent = null, Action onComplete = null)
    {
        var prefab = ObjectPool.Instance.Spawn(map);
        prefab.transform.SetLocalPositionAndRotation(postion, rotation);
        prefab.transform.SetParent(parent);
        prefab.SetActive(true);
        onComplete?.Invoke();
        await Task.Yield();
    }

    public async Task AddPlayer(Vector3 postion, Quaternion rotation, Transform parent = null, Action onComplete = null)
    {
        var player = ObjectPool.Instance.Spawn(playerPrefab);
        player.transform.SetLocalPositionAndRotation(postion, rotation);
        player.transform.SetParent(parent);
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector2.zero;

        GameEvent.OnAddPlayer?.Invoke(player.transform);
        onComplete?.Invoke();
        await Task.Yield();
    }

    //public void RemoveMap()
    //{
    //    if(map != null)
    //        map.SetActive(false);
    //}
}
