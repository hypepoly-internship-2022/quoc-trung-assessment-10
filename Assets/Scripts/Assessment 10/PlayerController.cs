using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Enemy;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Active,
    }

    [SerializeField] GameManager gameManager;

    PlayerState playerState;
    Camera mainCamera;
    Rigidbody playerRb;
    GameObject player;

    float xPos;
    float zPos;
    float speed = 6f;
    float amplitude = 0.2f;
    int groundIndex = 0;
    bool isDragging;
    
    
    private void Awake()
    {
        playerState = PlayerState.Idle;
        mainCamera = FindObjectOfType<Camera>();
        playerRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        switch (playerState)
        {
            case PlayerState.Idle:
                PlayerIdleState();
                break;
            case PlayerState.Active:
                PlayerActiveState();
                break;
        }
    }
    void PlayerIdleState()
    {
        ChangePlayerColor(PlayerState.Idle);
        ResetVelocity();
        ShakeObject();
        Invoke("SetPlayerStateActive", 2f);
    }
    void PlayerActiveState()
    {
        ChangePlayerColor(PlayerState.Active);
        DragObject();
        PushObject();
        Invoke("SetPlayerStateIdle", 1f);
    }
    void ChangePlayerColor(PlayerState playerState)
    {
        if (playerState == PlayerState.Idle)
        {
            transform.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        else if (playerState == PlayerState.Active)
        {
            transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    void SetPlayerStateIdle()
    {
        playerState = PlayerState.Idle;
    }

    void SetPlayerStateActive()
    {
        playerState = PlayerState.Active;  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            gameManager.SetGameManagerWinState();
        }
    }
    void DragObject()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            if (hits.Length >= 1)
            {
                xPos = hits[groundIndex].point.x;
                zPos = hits[groundIndex].point.z;

                if (hits.Length == 2)
                {
                    isDragging = true;
                    player = transform.gameObject;
                }
            }
            if(isDragging)
            {
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
                Vector3 pos = new Vector3(xPos, player.gameObject.transform.position.y, zPos);
                player.transform.position = pos;
            }
        }
        else
        {
            isDragging = false;
        }

    }
    void PushObject()
    {
        if (Input.GetMouseButton(0))
        {
            playerRb.AddForce(Vector3.forward.normalized * speed);
        }
        else
        {
            ResetVelocity();
        }
        
    }
    void ResetVelocity()
    {
        playerRb.velocity = Vector3.zero;
    }
    void ShakeObject()
    {
        float y = amplitude * Mathf.Sin(Time.time * 8);
        transform.position = new Vector3(transform.position.x, y + 0.7f, transform.position.z);
    }
}
