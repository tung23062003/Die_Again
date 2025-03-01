using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private GameObject menuLevelPanel;

    private void Awake()
    {
        playBtn.onClick.AddListener(PlayBtnHandle);
    }

    private void OnDestroy()
    {
        playBtn.onClick.RemoveAllListeners();
    }

    private void PlayBtnHandle()
    {
        menuLevelPanel.SetActive(true);
    }
}
