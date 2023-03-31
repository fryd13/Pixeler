using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public TextMeshProUGUI on, off;
    public void SoundsON()
    {
        on.color = new Color32(212, 94, 83, 255);
        off.color = new Color32(255, 255, 255, 255);
        PlayerPrefs.SetInt("soundsOff", 0);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
    }
    public void SoundsOff()
    {
        on.color = new Color32(255, 255, 255, 255);
        off.color = new Color32(212, 94, 83, 255);
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
        PlayerPrefs.SetInt("soundsOff", 1);
    }
}
