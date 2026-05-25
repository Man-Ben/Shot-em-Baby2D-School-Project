/*
Ez a script az akadályok viselkedését kezeli.
Folyamatosan mozgatja lefelé.
*/

using UnityEngine;

public class ManageObstacle : MonoBehaviour
{
    void Update()
    {
        float limit = -8;
    
        if(transform.position.y <= limit)
        {
            if(UIManager.Instance.gameState != UIManager.GameState.GameOver && UIManager.Instance.gameState != UIManager.GameState.Paused && !gameObject.CompareTag("EnemyProjectile"))
                UIManager.Instance.ReductScore();

            transform.position = new Vector2(0, 17);
            gameObject.SetActive(false);
        }
    }
}
