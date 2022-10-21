using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls the audio that plays in the game such as sound effects and background music
 */
public class AudioController : MonoBehaviour
{

    public static AudioController Instance;
    public  AudioSource pickUpItem;
    public AudioSource jump;
    public AudioSource laser;
    public AudioSource hit;
    public AudioSource bgMusic;
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
           
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        pickUpItem = pickUpItem.GetComponent<AudioSource>();
        jump = jump.GetComponent<AudioSource>();
        laser = laser.GetComponent<AudioSource>();
        hit = hit.GetComponent<AudioSource>();
        bgMusic = bgMusic.GetComponent<AudioSource>();
        
        //set the bg music volume as soon as game starts along with sound efects
        bgMusic.volume = SaveData.Instance.GetBGMusicVolume();
        jump.volume = SaveData.Instance.GetSoundEffectVolume();
       
    }


    public void PlayPickUpSoundEffect()
    {
        pickUpItem.Play();
    }
    public void PlayJumpSoundEffect()
    {
        jump.Play();
    }
    public void PlayLaserSoundEffect()
    {
        laser.Play();
    }

    public void PlayHitSoundEffect()
    {
        hit.Play();
    }

    public void PauseBGMusic()
    {
        bgMusic.Pause();
    }

    public void SetVolumeLevel()
    {
        bgMusic.volume = SaveData.Instance.GetBGMusicVolume();
    }
   
}