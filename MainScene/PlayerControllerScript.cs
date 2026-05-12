using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


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
        Shoot();
    }

    void MovePlayer()
    {
        float input = Input.GetAxis("Horizontal");

            transform.Translate(Vector2.right * playerSpeed * input * Time.deltaTime);
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Pool.Instance.GivePooledObject(Pool.PoolState.PoolProjectile);
            if(bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
            
        } 
    }
}
