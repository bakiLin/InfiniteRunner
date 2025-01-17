using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(.1f, 3f)]
        public float pitch;

        public bool loop;

        [HideInInspector]
        public AudioSource audioSource;
    }

    [Inject]
    private ButtonManager buttonManager;

    [SerializeField]
    private Sound[] sounds;

    private Tween tween;

    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }

        if (SceneManager.GetActiveScene().buildIndex.Equals(0))
            PlayerPrefs.SetInt("soundOn", 1);
        else
        {
            if (PlayerPrefs.GetInt("soundOn").Equals(1))
                TriggerSound("Theme", true);
            else
                buttonManager.SetSoundIcon(true);
        }
    }

    public void TriggerSound(string name, bool play)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound != null)
        {
            if (play)
            {
                sound.audioSource.Play();
                PlayerPrefs.SetInt("soundOn", 1);
            }
            else
            {
                sound.audioSource.Stop();
                PlayerPrefs.SetInt("soundOn", 0);
            }
        }
    }

    public void FadeSound(string name, float endValue, float duration)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound != null)
        {
            tween.Kill();
            tween = sound.audioSource.DOFade(endValue, duration).SetUpdate(true);
        }
    }

    public void ClickSound() => Array.Find(sounds, s => s.name == "Click").audioSource.Play();
}
