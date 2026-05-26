using UnityEngine;

public class UfoProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    void Update()
    {
        float limit = -8;

        if(UIManager.Instance.gameState == UIManager.GameState.Neutral)
            transform.Translate(Vector3.down * projectileSpeed * Time.deltaTime);    

        if(transform.position.y <= limit)
            gameObject.SetActive(false);

        if(UIManager.Instance.gameState == UIManager.GameState.GameOver)
            gameObject.SetActive(false);
    }

}
