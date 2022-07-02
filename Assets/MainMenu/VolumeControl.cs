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
        if((AudioListener.volume<=0.96&&volumeChange>0)||(AudioListener.volume>=-0&&volumeChange<0)){
            AudioListener.volume+=volumeChange;
            systemVariables.setVolume(AudioListener.volume);
            volumeValue.text = (Mathf.Round(AudioListener.volume*100)).ToString();
        }
        
    }
}
