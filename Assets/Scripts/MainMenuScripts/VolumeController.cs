using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioSource audioSource;
    public string volumeName;

    // Start is called before the first frame update
    void Start()
    {
        if (volumeName == "Music")
        {
            volumeSlider.value = SaveData.Instance.GetBGMusicVolume();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //System.Single needed to pass the volume slider value a 'dynamic' float in order to work
    public void VolumeSetting(System.Single v)
    {
        //Debug.Log(v);
        audioSource.volume = v;
        SaveData.Instance.SaveSettings(v, volumeName);
    }
}
