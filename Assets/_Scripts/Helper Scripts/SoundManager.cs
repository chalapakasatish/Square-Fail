using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource soundFX;
    public AudioSource music;
    public AudioClip landClip, deathClip, iceBreakClip, gameOverClip;
    public GameObject musicOn, musicOff, soundOn, soundOff;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
    private void Start()
    {
        PlayerPrefs.GetInt("Music",1);
        musicOn.SetActive(PlayerPrefs.GetInt("Music")==0);
        musicOff.SetActive(PlayerPrefs.GetInt("Music") == 1);
        Music(PlayerPrefs.GetInt("Music"));

        PlayerPrefs.GetInt("Sound", 1);
        soundOn.SetActive(PlayerPrefs.GetInt("Sound") == 0);
        soundOff.SetActive(PlayerPrefs.GetInt("Sound") == 1);
        Sound(PlayerPrefs.GetInt("Sound"));
    }
    public void Music(int value)
    {
        switch(value)
        {
            case 0:
                musicOn.SetActive(true);
                musicOff.SetActive(false);
                music.volume = 0.2f;
                break;
            case 1:
                musicOn.SetActive(false);
                musicOff.SetActive(true);
                music.volume = 0;
                break;
        }
    }
    public void Sound(int value)
    {
        switch (value)
        {
            case 0:
                soundOn.SetActive(true);
                soundOff.SetActive(false);
                soundFX.volume = 1f;
                break;
            case 1:
                soundOn.SetActive(false);
                soundOff.SetActive(true);
                soundFX.volume = 0;
                break;
        }
    }
    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }
    public void IceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }
    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }
    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }
}
