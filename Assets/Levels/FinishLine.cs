using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    Scene currentScene;
    [SerializeField] float finishDelay = 1f;
    [SerializeField] ParticleSystem winEffects;

    void Start(){
        currentScene = SceneManager.GetActiveScene();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            winEffects.Play();
            Invoke("levelFinish",finishDelay);
        }
    }

    void levelFinish(){
        SceneManager.LoadScene(currentScene.buildIndex);
        
    }
}
