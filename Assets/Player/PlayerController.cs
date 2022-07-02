using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueValue = 5f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float normalSpeed = 15f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] ParticleSystem trailEffects;
    [SerializeField] GameObject MainUI;
    [SerializeField] int backflipPoints;
    [SerializeField] int frontflipPoints;
    float startAngle = 0.0f;
    bool isTouchingGround = false;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    UI_ValuesUpdater changeValues;
    SystemVariables systemVariables;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        systemVariables = FindObjectOfType<SystemVariables>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        changeValues = MainUI.GetComponent<UI_ValuesUpdater>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = systemVariables.getPlayerSprite();
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            trailEffects.Stop();
            startAngle = transform.eulerAngles.z;
            isTouchingGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            trailEffects.Play();
            isTouchingGround = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleTorque();
        handleSpeed();
        handleJump();
        handleScore();
    }

    void handleJump(){
        if(Input.GetKey(KeyCode.Space)&&isTouchingGround){
            rb2d.AddForce(transform.up * jumpForce);
        }
    }

    void handleSpeed(){
        if(Input.GetKey(KeyCode.W)){
            surfaceEffector2D.speed = boostSpeed;
        } else {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    void handleTorque(){
        if(Input.GetKey(KeyCode.A)){
            rb2d.AddTorque(torqueValue);
        }
        else if(Input.GetKey(KeyCode.D)){
            rb2d.AddTorque(-torqueValue);
        }
    }

    void handleScore(){
        float frontflipAngle = startAngle+180;
        float backflipAngle = startAngle-180;
        if(frontflipAngle>= 360){
            frontflipAngle-=360;
        }
        if(backflipAngle<0){
            backflipAngle+=360;
        }
        if(!isTouchingGround){
            if(transform.eulerAngles.z>frontflipAngle&&startAngle<frontflipAngle){
                changeValues.incrementScore(frontflipPoints);
                startAngle = frontflipAngle;
                frontflipAngle = startAngle+180;
                if(frontflipAngle>= 180){
                    frontflipAngle-=360;
                }
            }
            if(transform.eulerAngles.z<backflipAngle&&startAngle>backflipAngle){
                changeValues.incrementScore(backflipPoints);
                startAngle = backflipAngle;
                backflipAngle = startAngle-180;
                Debug.Log(backflipAngle);
                if(frontflipAngle<= -180){
                    frontflipAngle+=360;
                }
            }
        }
    }
}
