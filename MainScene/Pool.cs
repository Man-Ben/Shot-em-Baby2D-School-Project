using System.Collections.Generic;
using UnityEngine;


public class Pool : MonoBehaviour
{

    public List<GameObject> pooledObstacles;
    public List<GameObject> pooledProjectiles;
    public List<GameObject> pooledEnemyProjectiles;
    public List<ParticleSystem> pooledParticles;
    
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject enemyProjectile;

    [SerializeField] ParticleSystem explosionParticle;

    [SerializeField] List<GameObject> obstacles;

    public enum PoolState
    {
        PoolProjectile,
        PoolObstacles,
        PoolEnemyProjectile
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

        PoolingObjects(projectile, 10, pooledProjectiles);
        PoolingObjects(enemyProjectile, 10, pooledEnemyProjectiles);

        foreach(var obstacle in obstacles)
            PoolingObjects(obstacle, 30, pooledObstacles);

        PoolingParticles(explosionParticle, 10, pooledParticles);

    }

    void PoolingObjects(GameObject objectToPool, int amountToPool, List<GameObject> pooledList)
    {
        GameObject tmp;

        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledList.Add(tmp);
        }   
    }

    void PoolingParticles(ParticleSystem particleToPool, int amountToPool, List<ParticleSystem> pooledParticle)
    {
        ParticleSystem tmp;

        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(particleToPool);
            tmp.gameObject.SetActive(false);
            pooledParticle.Add(tmp);
        } 
    }

    GameObject GetRandomPooledObstacle()
    {
        int index = Random.Range(0, pooledObstacles.Count);
        if(!pooledObstacles[index].activeSelf)
        {
            pooledObstacles[index].SetActive(true);
            return pooledObstacles[index];
        }

        return null;
    }

    GameObject GetPooledProjectile(List<GameObject> pooled)
    {
        for(int i = 0; i < 10; i++)
            if(!pooled[i].activeSelf)
                return pooled[i];

        return null;
    }

    public ParticleSystem GetExplosion()
    {
        for(int i = 0; i < 10; i++)
            if(!pooledParticles[i].gameObject.activeSelf)
                return pooledParticles[i];

        return null;
    }

    public GameObject GivePooledObject(PoolState poolState)
    {

        switch(poolState)
        {
            case PoolState.PoolObstacles:
                return GetRandomPooledObstacle();
            case PoolState.PoolProjectile:
                return GetPooledProjectile(pooledProjectiles);
            case PoolState.PoolEnemyProjectile:
                return GetPooledProjectile(pooledEnemyProjectiles);
        }

        return null;
    }

}
