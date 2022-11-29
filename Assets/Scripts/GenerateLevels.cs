using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GenerateLevels : MonoBehaviour
{
    [SerializeField] GameObject levelButtonPrefab;
    [SerializeField] Transform parent;
    //List<GameObject> levelButtons;

    private void Awake()
    {
        //levelButtons = new List<GameObject>();
        StartGenerateButtons();
    }

    void Start()
    {
        
        
    }

    void Update()
    {
        
    }

    GameObject CreateLevelSeclectButtons(int index)
    {
        GameObject levelSelectUI;
        Button levelSelectButton;
        TextMeshProUGUI levelText;

        levelSelectUI = Instantiate(levelButtonPrefab, parent);
        levelSelectButton = levelSelectUI.GetComponentInChildren<Button>();
        levelText = levelSelectButton.GetComponentInChildren<TextMeshProUGUI>();
        levelText.text = index.ToString();
        return levelSelectUI;
    }

    void StartGenerateButtons()
    {
        for (int i = 1 ; i <= 100; i++)
        {
            CreateLevelSeclectButtons(i);
        }
    }
}
