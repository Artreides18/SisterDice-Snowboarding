using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    Scene currentScene;
    [SerializeField] int firstLevelBuildNum;
    [SerializeField] int scoreboardBuildNum;
    [SerializeField] float buttonDelay = 1f;

    void Start(){
        currentScene = SceneManager.GetActiveScene();
    }

    public void HandleMenuInput(int button){
        switch(button){
            case 1:
                Invoke("startGame",buttonDelay);
            break;
            case 2:
                Invoke("goToScoreboard",buttonDelay);
            break;
            default:
                Invoke("quitGame",buttonDelay);
            break;
        }
    }

    void startGame(){
        SceneManager.LoadScene(firstLevelBuildNum);
    }

    void goToScoreboard(){
        SceneManager.LoadScene(scoreboardBuildNum);
    }

    void quitGame(){
        Application.Quit();
    }
}
