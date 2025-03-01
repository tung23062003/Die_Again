using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseLevelUI : MonoBehaviour
{
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button skipLevelBtn;

    [SerializeField] private GameObject lostLevelUI;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        retryBtn.onClick.AddListener(RetryBtnHandle);
        skipLevelBtn.onClick.AddListener(SkipLevelBtnHandle);

    }

    private void OnDestroy()
    {
        retryBtn.onClick.RemoveAllListeners();
        skipLevelBtn.onClick.RemoveAllListeners();

    }


    private void RetryBtnHandle()
    {
        animator.SetTrigger(Animator.StringToHash("Appear"));
        StartCoroutine(WaitForSeconds_Retry(1.5f));
    }

    private void SkipLevelBtnHandle()
    {
        animator.SetTrigger(Animator.StringToHash("Appear"));
        StartCoroutine(WaitForSeconds_Skip(1.5f));
    }

    private IEnumerator WaitForSeconds_Retry(float time)
    {
        yield return new WaitForSeconds(time);
        lostLevelUI.SetActive(false);
        GameManager.Instance.LoadLevel(isRestartLevel: true);
    }

    private IEnumerator WaitForSeconds_Skip(float time)
    {
        yield return new WaitForSeconds(time);
        lostLevelUI.SetActive(false);
        GameManager.Instance.LoadLevel(isSpawnNextLevel: true);
    }

}
