using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    public float sfxVolume;

    private void Awake()
    {
        if (instance != null && instance!= this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

  
