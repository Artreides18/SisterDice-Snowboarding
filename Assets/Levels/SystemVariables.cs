using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemVariables : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] float volume;
    [SerializeField] Sprite playerSprite;

    public void setPlayerSprite(Sprite newSprite){
        playerSprite = newSprite;
    }

    public Sprite getPlayerSprite(){
        return playerSprite;
    }

    public void setScore(int change){
        score=change;
    }

    public int getScore(){
        return score;
    }

    public void setVolume(float change){
        volume=change;
    }

    public float getVolume(){
        return volume;
    }

    // Start is called before the first frame update
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
}
