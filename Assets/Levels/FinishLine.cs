using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    Scene currentScene;
    [SerializeField] float finishDelay = 1f;
    [SerializeField] ParticleSystem winEffects;
    SystemVariables systemVariables;
    UI_ValuesUpdater score;

    void Start(){
        systemVariables = FindObjectOfType<SystemVariables>();
        score = FindObjectOfType<UI_ValuesUpdater>();
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
        systemVariables.setScore(score.getScore());
        SceneManager.LoadScene(currentScene.buildIndex+1);
        
    }
}
