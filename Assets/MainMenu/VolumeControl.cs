using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeControl : MonoBehaviour
{
    SystemVariables systemVariables;
    [SerializeField] TextMeshProUGUI volumeValue;

    void Awake(){
        systemVariables = FindObjectOfType<SystemVariables>();
        AudioListener.volume = systemVariables.getVolume();
        volumeValue.text = (Mathf.Round(AudioListener.volume*100)).ToString();
    }

    public void changeVolume(float volumeChange){
        if((AudioListener.volume+volumeChange<=1.04)&&(AudioListener.volume-volumeChange>=0.05)){
            Debug.Log(AudioListener.volume+volumeChange);
            AudioListener.volume+=volumeChange;
            systemVariables.setVolume(AudioListener.volume);
            volumeValue.text = (Mathf.Round(AudioListener.volume*100)).ToString();
        }
        
    }
}
