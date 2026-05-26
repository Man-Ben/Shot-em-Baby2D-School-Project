/*
Ez a script az akadályok viselkedését kezeli.
A testeket a játék motor mozgatja lefelé (Rigidbody 2D, gravity).
Ha az akadályok elérik a limitet kikapcsolnak.
*/

using UnityEngine;

public class ManageObstacle : MonoBehaviour
{
    void Update()
    {
        float limit = -8;

        if(UIManager.Instance.gameState == UIManager.GameState.GameOver)
            gameObject.SetActive(false);
    
        if(transform.position.y <= limit)
        {
            UIManager.Instance.ReductScore();

            transform.position = new Vector2(0, 17);
            gameObject.SetActive(false);
        }
    }
}
