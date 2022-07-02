using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreboardScript : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> scoreValues;
    SystemVariables systemVariables;

    void Awake(){
        loadScoreTable();
        systemVariables = FindObjectOfType<SystemVariables>();
        if(systemVariables){
            addScore(systemVariables.getScore());
        }   
    }

    public void returnToMenu(){
        SceneManager.LoadScene(0);
    }

    void loadScoreTable(){
        for(int i = 0;i<scoreValues.Count;i++){
            scoreValues[i].text=PlayerPrefs.GetInt(i.ToString(),0).ToString();
        }
    }

    void addScore(int score){
        for(int i = 0;i<scoreValues.Count;i++){
            if(score>int.Parse(scoreValues[i].text)){
                for(int j = scoreValues.Count-1;j>i;j--){
                    scoreValues[j].text = scoreValues[j-1].text;
                    PlayerPrefs.SetInt(j.ToString(),int.Parse(scoreValues[j-1].text));
                }
                scoreValues[i].text=score.ToString();
                PlayerPrefs.SetInt(i.ToString(),score);
                score = 0;
            }
        }
    }
}
