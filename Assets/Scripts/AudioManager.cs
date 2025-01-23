using DG.Tweening;
using System;
using UnityEngine;

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

    [SerializeField]
    private Sound[] sounds;

    private static AudioManager Instance;

    private Tween tween;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        PlayerPrefs.SetInt("soundOn", 1);

        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }

    public void TriggerSound(string name, bool play)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound != null)
        {
            if (play)
            {
                sound.audioSource.volume = 0.5f;
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

    public void ClickSound()
    {
        Array.Find(sounds, s => s.name == "Click").audioSource.Play();
    }

    public void PlayTheme()
    {
        TriggerSound("Theme", true);
    }
}
