using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonSound : MonoBehaviour
{
    Button button;
    AudioSource audioSource;
    private void Awake()
    {
        button = GetComponent<Button>();
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
   
    void Update()
    {
        button.onClick.AddListener(PlaySound);
    }
    void PlaySound()
    {
        audioSource.Play();
    }
}
