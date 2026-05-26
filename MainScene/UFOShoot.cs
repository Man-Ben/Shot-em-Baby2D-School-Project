/*
    Ez a script az UFO-kat kezeli. Spawnolás után azonnal lőni kezdenek. 
*/

using System.Collections;
using UnityEngine;

public class UfoShoot : MonoBehaviour
{
    [SerializeField] AudioClip gunSound;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        if(MainUI.Instance.difficulty != MainUI.Difficulty.Easy)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        while(UIManager.Instance.gameState != UIManager.GameState.GameOver)
        {
            yield return new WaitUntil(() => UIManager.Instance.gameState != UIManager.GameState.Paused);
            
            GameObject bullet = Pool.Instance.GivePooledObject(Pool.PoolState.PoolEnemyProjectile);
            
            if(bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                audioSource.PlayOneShot(gunSound, 0.3f);
                bullet.SetActive(true);
            }

            yield return new WaitForSecondsRealtime(0.5f);
        }
        
    }
}
