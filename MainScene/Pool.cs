using System.Collections.Generic;
using UnityEngine;


public class Pool : MonoBehaviour
{

    public List<GameObject> pooledObstacles;
    public List<GameObject> pooledProjectiles;
    
    [SerializeField] GameObject projectile;

    [SerializeField] List<GameObject> obstacles;

    public enum PoolState
    {
        PoolProjectile,
        PoolObstacles
    }

    public static Pool Instance {get; private set;}

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Pooling(projectile, 10, pooledProjectiles);

        foreach(var obstacle in obstacles)
            Pooling(obstacle, 30, pooledObstacles);

    }

    void Pooling(GameObject objectToPool, int amountToPool, List<GameObject> pooledList)
    {
     GameObject tmp;

        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledList.Add(tmp);
        }   
    }

    GameObject GetRandomPooled()
    {
        int index = Random.Range(0, pooledObstacles.Count);
        if(!pooledObstacles[index].activeSelf)
        {
            pooledObstacles[index].SetActive(true);
            return pooledObstacles[index];
        }

        return null;
    }

    GameObject GetPooled()
    {
        for(int i = 0; i < 10; i++)
            if(!pooledProjectiles[i].activeSelf)
                return pooledProjectiles[i];

        return null;
    }

    public GameObject GivePooledObject(PoolState poolState)
    {

        switch(poolState)
        {
            case PoolState.PoolObstacles:
                return GetRandomPooled();
            
            case PoolState.PoolProjectile:
                return GetPooled();
        }

        return null;
    }

}
