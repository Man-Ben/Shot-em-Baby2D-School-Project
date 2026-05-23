using System;
using UnityEngine;


public class PlayerControllerScript : MonoBehaviour
{
    
    [SerializeField] ParticleSystem explosionParticle;
    
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip engineSound;
    [SerializeField] AudioClip gunSound;

    AudioSource audioSource;

    bool playerDied = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        

        if(UIManager.Instance.gameState != UIManager.GameState.Paused && UIManager.Instance.gameState != UIManager.GameState.GameOver)
        {
            MovePlayer();
            Shoot();
        }
        
    }

    void MovePlayer()
    {
        float input = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

            transform.position = new Vector2(input, -3f);
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
                audioSource.PlayOneShot(gunSound, 0.3f);
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(UIManager.Instance.gameState != UIManager.GameState.Paused && UIManager.Instance.gameState != UIManager.GameState.GameOver)
            if(collider.CompareTag("UFO") || collider.CompareTag("Meteor") || collider.CompareTag("Bird"))
                UIManager.Instance.InactivateHealth();

        if(UIManager.Instance.gameState == UIManager.GameState.GameOver && !playerDied)
        {
            audioSource.PlayOneShot(explosionSound, 0.3f);
            explosionParticle.Play();
            playerDied = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(UIManager.Instance.gameState != UIManager.GameState.Paused && UIManager.Instance.gameState != UIManager.GameState.GameOver)
                UIManager.Instance.InactivateHealth();

        if(UIManager.Instance.gameState == UIManager.GameState.GameOver && !playerDied)
        {
            audioSource.PlayOneShot(explosionSound, 0.5f);
            explosionParticle.Play();
            playerDied = true;
        }
    }
}
