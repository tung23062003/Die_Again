using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateUI : MonoBehaviour
{
    [SerializeField] private GameObject lostLevelPanel;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        GameEvent.OnStartLevel.AddListener(OnStartLevel);
        //GameEvent.OnWinLevel.AddListener(OnEndLevel);
        //GameEvent.OnLoseLevel.AddListener(OnEndLevel);

        GameEvent.OnEndLevel.AddListener(OnEndLevel);
    }

    private void OnDestroy()
    {
        GameEvent.OnStartLevel.RemoveAllListeners();
        //GameEvent.OnWinLevel.RemoveAllListeners();
        //GameEvent.OnLoseLevel.RemoveAllListeners();
    }

    private void Start()
    {
        
    }

    private void OnStartLevel()
    {
        animator.SetTrigger(Animator.StringToHash("Disapear"));
    }

    private void OnEndLevel(EndLevelType endLevelType)
    {
        animator.SetTrigger(Animator.StringToHash("Appear"));

        if(endLevelType == EndLevelType.Win)
            StartCoroutine(WaitForSeconds_Win(1.5f));
        else if(endLevelType == EndLevelType.Lose)
            StartCoroutine(WaitForSeconds_Lose(1.5f));
    }

    private IEnumerator WaitForSeconds_Win(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.LoadLevel(isSpawnNextLevel: true);
    }

    private IEnumerator WaitForSeconds_Lose(float time)
    {
        yield return new WaitForSeconds(time);
        lostLevelPanel.SetActive(true);
    }
}
