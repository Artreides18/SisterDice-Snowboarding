using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueValue = 5f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float normalSpeed = 15f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] ParticleSystem trailEffects;
    bool isTouchingGround = false;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag == "Ground"){
            trailEffects.Stop();
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
}
