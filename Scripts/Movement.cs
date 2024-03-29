using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    [SerializeField] float turnSpeed;
    [SerializeField] float frontSpeed;
    [SerializeField] int actualColumn;
    [SerializeField] bool canMove;
    
    void Start(){
        canMove = true;
        actualColumn = 0;
    }

    void Update(){
        ProcessInput();
        transform.Translate(Vector3.forward * Time.deltaTime * frontSpeed);
    }

    void ProcessInput(){

        if(Input.GetKey(KeyCode.A)){
            if(canMove){ moveLeft(); }
        }
        else if(Input.GetKey(KeyCode.D)){
            if(canMove){ moveRight(); }
        }

    }

    public void moveRight(){
        if(actualColumn < 1){
            canMove = false;
            Invoke("restoreMovement",0.5f);
            for(float i = 0; i < 0.33f; i+=0.005f){
                Invoke("rightMov", 0.05f+i);
            }
            actualColumn++;
        }
    }

    public void moveLeft(){
        if(actualColumn > -1){
            canMove = false;
            Invoke("restoreMovement",0.5f);
            for(float i = 0; i < 0.33f; i+=0.005f){
                Invoke("leftMov", 0.05f+i);
            }
            actualColumn--;
        }
    }

    void leftMov(){
        transform.Translate(Vector3.left * turnSpeed, Space.World);
    }

    void rightMov(){
        transform.Translate(Vector3.right * turnSpeed, Space.World);
    } 

    void restoreMovement(){
        canMove = true;
    }
}