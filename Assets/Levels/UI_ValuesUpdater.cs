using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_ValuesUpdater : MonoBehaviour
{
    int score = 0;
    [SerializeField] TextMeshProUGUI scoreValue;

    public void Awake(){
        scoreValue.text = score.ToString();
    }

    public void incrementScore(int scoreChange){
        score+=scoreChange;
        scoreValue.text = score.ToString();
    }
}
