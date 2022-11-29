using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ShowButtonDetail : MonoBehaviour
{
    Transform[] buttonChildren;

    int buttonIndex;
    string buttonContent;

    Transform indexObject;
    Transform contentObject;

    private void Awake()
    {
        buttonChildren = gameObject.GetComponentsInChildren<Transform>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void DisplayButtonDetail()
    {
        foreach(Transform child in buttonChildren)
        {
            if(child.tag == "ButtonNumber")
            {
                indexObject = child;
                buttonIndex = int.Parse(indexObject.GetComponentInChildren<TextMeshProUGUI>().text);  
            }
            else if(child.tag == "ButtonContent")
            {
                contentObject = child;
                buttonContent = contentObject.GetComponent<TextMeshProUGUI>().text;
            }
        }
        CheckIndex(buttonIndex);
    }
    void CheckIndex(int index)
    {
        if (index % 3 == 0)
        {
            Debug.Log(buttonIndex);
        }
        else
        {
            Debug.Log(buttonContent);
        }
    }
}
