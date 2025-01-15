using DG.Tweening;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private ParticleSystem system;

    private void Awake() => system = GetComponent<ParticleSystem>();

    public void ParticlePlay()
    {
        system.Play();

        transform.DOMoveZ(-20f, 10f)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(() => {
                gameObject.SetActive(false);
            });
    } 
}
