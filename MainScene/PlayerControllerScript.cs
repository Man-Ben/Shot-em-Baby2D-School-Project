/*
Ez a script a player irányitását kezeli, hogy lekövesse a mouse-t.
Bal klickre lő eggyet es a lövés hangját is lejátsza.
Levonja az életet, ha szukséges.
*/

using UnityEngine;


public class PlayerControllerScript : MonoBehaviour
{
    
    [SerializeField] AudioClip engineSound;
    [SerializeField] AudioClip gunSound;

    AudioSource audioSource;

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
        
        if(UIManager.Instance.gameState == UIManager.GameState.GameOver)
        {
            gameObject.SetActive(false);
            Explosion.Instance.PlayExplosion(transform.position.x, transform.position.y);
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
                
                audioSource.PlayOneShot(gunSound, 0.3f);
                bullet.SetActive(true);
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(UIManager.Instance.gameState != UIManager.GameState.Paused && UIManager.Instance.gameState != UIManager.GameState.GameOver)
            if(collider.CompareTag("UFO") || collider.CompareTag("Meteor") || collider.CompareTag("Bird") || collider.CompareTag("EnemyProjectile"))
                UIManager.Instance.InactivateHealth();

    }

}
