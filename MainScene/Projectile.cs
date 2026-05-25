/*
Ez a script a játékos lövedékeinek a viselkedését kezeli.
Ha ütközik egy objektummal, ami nem a player kikapcsolja önmagát és az objektumot amivel ütközött.
Ha túllép egy határt ütközés nélkül kikapcsol.
*/

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;


    void Update()
    {
        
        if(UIManager.Instance.gameState == UIManager.GameState.Neutral)
        {
            transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
            ResetPosition();
        }
        if(UIManager.Instance.gameState == UIManager.GameState.GameOver)
            gameObject.SetActive(false);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            return;

        Explosion.Instance.PlayExplosion(collision.transform.position.x, collision.transform.position.y);
        
        if(UIManager.Instance.gameState == UIManager.GameState.Neutral)
        {
            if(collision.CompareTag("UFO") || collision.CompareTag("EnemyProjectile"))
                UIManager.Instance.AddScore(true);
            else
                UIManager.Instance.AddScore(false);

            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        
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
