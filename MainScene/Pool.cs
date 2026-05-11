using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance;

    public List<GameObject> pooledObstacles;
    public List<GameObject> pooledProjectiles;
    
    [SerializeField] GameObject projectile;

    [SerializeField] List<GameObject> obstacles;

    public enum PoolState
    {
        PoolProjectile,
        PoolObstacles
    }

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    void PoolingObstacles()
    {
        
    }

}
