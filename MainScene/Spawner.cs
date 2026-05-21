using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int spawnWave;

    void Awake()
    {
        SetWave();
    }
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
                for(int i = 0; i < spawnWave; i++)
                    gotObject.transform.position = new Vector2(RandomPosition(), 20);
            

            yield return new WaitForSeconds(1);
        }
    }

    void SetWave()
    {
        switch(MainUI.Instance.difficulty)
        {
            case MainUI.Difficulty.Easy:
            spawnWave = 3;
            break;

            case MainUI.Difficulty.Normal:
            spawnWave = 2;
            break;

            case MainUI.Difficulty.Hard:
            spawnWave = 1;
            break;
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
