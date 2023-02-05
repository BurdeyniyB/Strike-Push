using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundsetting : MonoBehaviour
{
    [SerializeField] private string Load_text;
    private int load;

    void Update()
    {
     load = PlayerPrefs.GetInt(Load_text);

     if(load == 1)
     {
        PlayerPrefs.SetInt(Load_text, 0);
        GetComponent<AudioSource>().Play();
      }
     }
}
