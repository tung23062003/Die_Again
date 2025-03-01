using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelUI : MonoBehaviour
{
    [SerializeField] private Button backBtn;
    [SerializeField] private GameObject menuLevelPanel;
    [SerializeField] private LevelDataSO levelData;
    [SerializeField] private GameObject levelBtnPrefab;
    [SerializeField] private Transform levelBtnParent;

    [SerializeField] private List<Sprite> levelBtnSprites;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        backBtn.onClick.AddListener(BackBtnHandle);
    }

    private void OnDestroy()
    {
        backBtn.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        int levelQuantity = levelData.GetLevelQuantity();
        for (int i = 0; i < levelQuantity; i++)
        {
            int level = i + 1;
            var prefab = Instantiate(levelBtnPrefab, levelBtnParent);
            if(i <= PlayerPrefs.GetInt("Level", 1) - 1)
            {
                prefab.GetComponent<Image>().sprite = levelBtnSprites[0];
                prefab.GetComponent<Button>().interactable = true;
                prefab.GetComponent<Button>().onClick.AddListener(() => { LevelBtnHandle(level); });
            }
            else
            {
                prefab.GetComponent<Image>().sprite = levelBtnSprites[1];
                prefab.GetComponent<Button>().interactable = false;
            }
            prefab.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            
        }
    }

    private void LevelBtnHandle(int level)
    {
        StartCoroutine(WaitForLoadMainScene(1.5f, level));
    }

    private IEnumerator WaitForLoadMainScene(float time, int level)
    {
        animator.SetTrigger(Animator.StringToHash("Appear"));

        yield return new WaitForSeconds(time);

        GameManager.Instance.loadingLevel = level;
        GameManager.Instance.LoadScene(GameConstants.MAIN_SCENE);
    }


    private void BackBtnHandle()
    {
        menuLevelPanel.SetActive(false);
    }
}
