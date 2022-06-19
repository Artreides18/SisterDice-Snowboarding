using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    Scene currentScene;
    [SerializeField] float crashWait = 1f;
    [SerializeField] ParticleSystem crashEffects;

    void Start(){
        currentScene = SceneManager.GetActiveScene();
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ground"){
            crashEffects.Play();
            Invoke("reloadScene",crashWait);
        }      
    }

    void reloadScene(){
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
