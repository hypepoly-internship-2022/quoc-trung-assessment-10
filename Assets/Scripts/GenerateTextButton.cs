using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GenerateTextButton : MonoBehaviour
{
    [SerializeField] GameObject textButtonPrefab;
    [SerializeField] Transform parent;
    [SerializeField] int numberOfButton;
    [SerializeField] string[] contents;
    void Start()
    {
        StartGenerateTextButton();
    }

    void Update()
    {
        
    }
    void StartGenerateTextButton()
    {
        for (int i = 1; i <= numberOfButton; i++)
        {
            GenerateButtonTextButton(i);
        }
    }
    void GenerateButtonTextButton(int index)
    {
        GameObject textButtonWithIndex;

        Transform numberButton;
        Transform contentButton;
        
        TextMeshProUGUI buttonIndex;
        TextMeshProUGUI buttonContent;

        int radomNum;

        textButtonWithIndex = Instantiate(textButtonPrefab, parent);

        Transform[] allChildren = textButtonWithIndex.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            if (child.gameObject.tag == "ButtonNumber")
            {
                numberButton = child;
                buttonIndex = numberButton.GetComponentInChildren<TextMeshProUGUI>();
                buttonIndex.text = index.ToString();
            }
            else if(child.gameObject.tag == "ButtonContent")
            {
                contentButton = child;
                buttonContent = contentButton.GetComponentInChildren<TextMeshProUGUI>();
                radomNum = GenetateRandomNumber();
                buttonContent.text = contents[radomNum];
            }
        }    
    }
    int GenetateRandomNumber()
    {
        return Random.Range(0, contents.Length);
    }
}
