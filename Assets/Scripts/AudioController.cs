using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
       
    }

    // Update is called once per frame
    void Update()
    {
        
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
   
}
