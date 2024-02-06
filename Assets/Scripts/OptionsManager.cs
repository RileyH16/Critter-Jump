using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

        public Slider volume, sfx;
 
    public void SetVolume(float bgmvolume)
    {
        AudioManager.Instance.GetComponent<AudioSource>().volume = bgmvolume;
        PlayerPrefs.SetFloat("volume", bgmvolume);
    }

    public void SetSfxVolume(float sfxvolume)
    {
        AudioManager.Instance.sfxVolume = sfxvolume;
        PlayerPrefs.SetFloat("sfx", sfxvolume);
    }

    // Start is called before the first frame update
    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("volume", 1);
        sfx.value = PlayerPrefs.GetFloat("sfx", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
