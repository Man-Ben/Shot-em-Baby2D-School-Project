using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] AudioClip explosionSound;

    AudioSource audioSource;

    public static Explosion Instance;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayExplosion(float explosionCoordinatesX, float explosionCoordinatesY)
    {
        audioSource.PlayOneShot(explosionSound, 0.7f);

        ParticleSystem gotParticle = Pool.Instance.GetExplosion();

        if(gotParticle != null)
        {
            gotParticle.gameObject.transform.position = new Vector2(explosionCoordinatesX, explosionCoordinatesY);
            
            gotParticle.gameObject.SetActive(true);
            gotParticle.Play();
            
            StartCoroutine(ReturnToPool(gotParticle));
        }
    }

    IEnumerator ReturnToPool(ParticleSystem particleSystem)
    {
        yield return new WaitForSecondsRealtime(1);

        particleSystem.Stop();
        particleSystem.Clear();

        particleSystem.gameObject.SetActive(false);
    }
}
