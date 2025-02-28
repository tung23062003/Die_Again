using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float distance = 8.0f;
    [SerializeField] private float distance2 = 8.0f;

    private void Awake()
    {
        GameEvent.OnAddPlayer.AddListener(OnAddPlayer);
    }

    private void OnDestroy()
    {
        GameEvent.OnAddPlayer.RemoveAllListeners();
    }

    private void OnAddPlayer(Transform playerTrans)
    {
        target = playerTrans;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;
        Camera.main.transform.position = new Vector3(target.position.x, target.position.y + distance2, target.position.z - distance);
    }
}
