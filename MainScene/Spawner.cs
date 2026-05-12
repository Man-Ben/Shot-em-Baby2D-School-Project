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

        while(true)
        {
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
