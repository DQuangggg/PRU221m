using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;

    [SerializeField] AudioSource musicSource, sfxSource;
    [SerializeField] private AudioMixer musicMixer, sfxMixer;
    [SerializeField] private Slider musicSlider, sfxSlider;

    public AudioClip music1, music6, music7, gamewin;
    public AudioClip dead, dead2, gameover, jump;

    public AudioClip musicIsPlay;

    void Start()
    {
        musicSource.clip = musicIsPlay;
        musicSource.Play();

        if(musicSlider?.value != null && sfxSlider?.value != null)
        {
            if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("SFXVolume"))
            {
                LoadVolume();
            }
            else if (PlayerPrefs.HasKey("musicVolume"))
            {
                musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
                SetMusicVolume();
            }
            else if (PlayerPrefs.HasKey("SFXVolume"))
            {
                sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
                SetSFXVolume();
            }
            else
            {
                SetMusicVolume();
                SetSFXVolume();
            }
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }


    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        musicMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        sfxMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }

}
