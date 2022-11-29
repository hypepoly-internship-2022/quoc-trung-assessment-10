using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonIndex : MonoBehaviour
{
    private void Awake()
    {
        
    }
    void Start()
    {
    
    }

    void LateUpdate()
    {
        
    }
    public void DisplayButtonIndex()
    {
        Debug.Log(gameObject.GetComponentInChildren<TextMeshProUGUI>().text);
        
    }
}
