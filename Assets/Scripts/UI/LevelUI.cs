using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        GameEvent.OnStartLevel.AddListener(OnStartLevel);
        GameEvent.OnWinLevel.AddListener(OnEndLevel);
    }

    private void OnDestroy()
    {
        GameEvent.OnStartLevel.RemoveAllListeners();
        GameEvent.OnWinLevel.RemoveAllListeners();
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnStartLevel()
    {
        animator.SetTrigger(Animator.StringToHash("Disapear"));
    }

    private void OnEndLevel()
    {
        animator.SetTrigger(Animator.StringToHash("Appear"));
        //GameManager.Instance.LoadNextLevel();
    }
}
