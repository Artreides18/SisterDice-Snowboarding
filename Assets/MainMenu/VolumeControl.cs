using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeControl : MonoBehaviour
{
    SystemVariables systemVariables;
    [SerializeField] TextMeshProUGUI volumeValue;
    AudioSource audioSource;

    void Awake(){
        systemVariables = FindObjectOfType<SystemVariables>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = systemVariables.getVolume();
    }

    public void changeVolume(float volumeChange){
        audioSource.volume+=volumeChange;
        systemVariables.setVolume(audioSource.volume);
        volumeValue.text = (Mathf.Round(audioSource.volume*100)).ToString();
    }
}
