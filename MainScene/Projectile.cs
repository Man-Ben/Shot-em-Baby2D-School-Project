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
        
        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
        UIManager.Instance.AddScore();
    }

    void ResetPosition()
    {
        float limit = 17;

        if(transform.position.y >= limit)
        {
            gameObject.SetActive(false);
            
        }
    }
}
