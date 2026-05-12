using UnityEngine;

public class ResetObstacle : MonoBehaviour
{
    

    void Update()
    {
        float limit = -8;

        if(transform.position.y <= limit)
        {
            transform.position = new Vector2(0, 17);
            gameObject.SetActive(false);
        }
    }
}
