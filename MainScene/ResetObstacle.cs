using Unity.VisualScripting;
using UnityEngine;

public class ResetObstacle : MonoBehaviour
{
    void Update()
    {
        float limit = -8;

        if(transform.position.y <= limit)
        {
            if(UIManager.Instance.gameState != UIManager.GameState.GameOver && UIManager.Instance.gameState != UIManager.GameState.Paused)
                UIManager.Instance.ReductScore();

            transform.position = new Vector2(0, 17);
            gameObject.SetActive(false);
        }
    }
}
