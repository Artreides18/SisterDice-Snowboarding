using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChange : MonoBehaviour
{

    [SerializeField] List<Sprite> PossibleSprites;
    SystemVariables systemVariables;
    int currentSprite = 0;
    Image currentImage;

    void Start(){
        systemVariables = FindObjectOfType<SystemVariables>();
        currentImage = gameObject.GetComponent<Image>();
    }

    public void changeSprite(int direction){
        if(direction>0){
            currentSprite++;
            if(currentSprite>=PossibleSprites.Count){
                currentSprite = 0;
            }
        } else {
            currentSprite--;
            if(currentSprite<=-1){
                currentSprite = PossibleSprites.Count-1;
            }
        }
        currentImage.sprite = PossibleSprites[currentSprite];
        systemVariables.setPlayerSprite(PossibleSprites[currentSprite]);
    }
    


}
