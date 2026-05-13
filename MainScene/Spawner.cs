using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SpawnIntervals());
    }

    IEnumerator SpawnIntervals()
    {

        while(UIManager.Instance.gameState != UIManager.GameState.GameOver)
        {
            yield return new WaitUntil(() => UIManager.Instance.gameState == UIManager.GameState.Neutral);
            
            GameObject gotObject = Pool.Instance.GivePooledObject(Pool.PoolState.PoolObstacles);

            if(gotObject != null)
                gotObject.transform.position = new Vector2(RandomPosition(), 20);
            

            yield return new WaitForSeconds(2);
        }
    }

    float RandomPosition()
    {
        float minX = -13;
        float maxX = 13;

        float positionX = Random.Range(minX, maxX);

        return positionX;
    }
}
