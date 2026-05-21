using UnityEngine;


public class PlayerControllerScript : MonoBehaviour
{
    
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
        float input = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;//Input.GetAxis("Horizontal");

            transform.position = new Vector2(input, -3.65f);
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
