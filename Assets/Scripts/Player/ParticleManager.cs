using System.Collections;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private ParticleSystem system;

    private void Awake()
    {
        system = GetComponent<ParticleSystem>();
    }

    public void ParticleBehaviour()
    {
        system.Play();
        StartCoroutine(ParticleBehaviourCoroutine());
    }

    private IEnumerator ParticleBehaviourCoroutine()
    {
        float time = 0;

        while (time < 3f)
        {
            Vector3 position = transform.position;
            position.z -= Time.deltaTime * moveSpeed;
            transform.position = position;
            time += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
