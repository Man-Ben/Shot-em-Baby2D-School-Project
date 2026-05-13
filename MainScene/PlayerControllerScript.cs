using UnityEngine;


public class PlayerControllerScript : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(UIManager.Instance.gameState != UIManager.GameState.Paused && UIManager.Instance.gameState != UIManager.GameState.GameOver)
            if(collider.CompareTag("UFO") || collider.CompareTag("Meteor"))
                UIManager.Instance.InactivateHealth();
    }
}
