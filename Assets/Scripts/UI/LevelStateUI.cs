using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStateUI : MonoBehaviour
{
    [SerializeField] private Button homeBtn;
    [SerializeField] private GameObject lostLevelPanel;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        homeBtn.onClick.AddListener(HomeBtnHandle);

        GameEvent.OnStartLevel.AddListener(OnStartLevel);
        GameEvent.OnEndLevel.AddListener(OnEndLevel);
    }

    private void OnDestroy()
    {
        homeBtn.onClick.RemoveAllListeners();

        GameEvent.OnStartLevel.RemoveAllListeners();
        GameEvent.OnEndLevel.RemoveAllListeners();
    }

    private void HomeBtnHandle()
    {
        GameManager.Instance.LoadScene(GameConstants.MENU_SCENE, () => { GameManager.Instance.DestroySingleton(); });
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
