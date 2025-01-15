using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
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
    private IconsManager iconsManager;

    [SerializeField]
    private Image soundButtonImage;

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
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("soundOn"))
        {
            if (PlayerPrefs.GetInt("soundOn") == 1)
                PlaySound("Theme");
            else
                soundButtonImage.sprite = iconsManager.soundOn;
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound != null) 
            sound.audioSource.Play();
    }

    public void PauseSound(string name, bool isPaused)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound != null)
        {
            if (!isPaused)
            {
                tween.Kill();
                tween = sound.audioSource.DOFade(.1f, .1f).SetUpdate(true);
            }
            else
            {
                tween.Kill();
                tween = sound.audioSource.DOFade(.5f, .1f).SetUpdate(true);
            }
        }
    }
    
    public void StopSound(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound != null)
            sound.audioSource.Stop();

        PlayerPrefs.SetInt("soundOn", 0);
    } 

    public void FadeSoundToZero(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        if (sound != null)
        {
            tween.Kill();
            tween = sound.audioSource.DOFade(0f, 1f).SetUpdate(true);
        }
    }
}
