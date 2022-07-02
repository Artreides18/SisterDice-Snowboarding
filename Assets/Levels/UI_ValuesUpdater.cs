using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_ValuesUpdater : MonoBehaviour
{
    int score = 0;
    int startScore;
    [SerializeField] TextMeshProUGUI scoreValue;
    SystemVariables systemVariables;

    public void Awake(){
        systemVariables = FindObjectOfType<SystemVariables>();
        startScore = systemVariables.getScore();
        score = startScore;
        scoreValue.text = score.ToString();
    }

    public int getScore(){
        return score;
    }

    public void incrementScore(int scoreChange){
        score+=scoreChange;
        scoreValue.text = score.ToString();
    }
}
