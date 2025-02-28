using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLevelUI : MonoBehaviour
{
    [SerializeField] private GameObject lostLevelUI;

    private void Awake()
    {
        GameEvent.OnLoseLevel.AddListener(OnLoseLevel);
    }

    private void OnDestroy()
    {
        GameEvent.OnLoseLevel.RemoveAllListeners();
    }


    private void OnLoseLevel()
    {
        lostLevelUI.SetActive(true);
    }
}
