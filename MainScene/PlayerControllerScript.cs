using System;
using UnityEngine;


public class PlayerControllerScript : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    private Rigidbody2D playerRb;

    void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();    
    }

    
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float input = Input.GetAxis("Horizontal");

            playerRb.AddForce(Vector2.right * playerSpeed * input);
    }
}
