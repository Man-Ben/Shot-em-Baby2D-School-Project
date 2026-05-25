/*
Ez a script a lövedékek viselkedését kezeli.
A player és az UFO lövedékei is ezt használják.
*/

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;


    void Update()
    {
        
        if(UIManager.Instance.gameState != UIManager.GameState.Paused && UIManager.Instance.gameState != UIManager.GameState.GameOver)
        {
            transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
            ResetPosition();
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            return;

        Explosion.Instance.PlayExplosion(collision.transform.position.x, collision.transform.position.y);
        
        if(collision.CompareTag("UFO") || collision.CompareTag("EnemyProjectile"))
            UIManager.Instance.AddScore(true);
        else
            UIManager.Instance.AddScore(false);

        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    void ResetPosition()
    {
        float limit = 15;

        if(transform.position.y >= limit)
        {
            gameObject.SetActive(false);
        }
    }
}
