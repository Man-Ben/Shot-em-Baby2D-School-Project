using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;

    void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
        ResetPosition();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            return;
        
        collision.gameObject.SetActive(false);
        gameObject.SetActive(false);
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
