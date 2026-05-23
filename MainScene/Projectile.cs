using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;

    [SerializeField] ParticleSystem explosionParticle;

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

        StartCoroutine(Explosion());

        collision.gameObject.SetActive(false);
        UIManager.Instance.AddScore();
    }

    IEnumerator Explosion()
    {
        explosionParticle.Play();

        yield return new WaitForSecondsRealtime(0.1f);        

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
