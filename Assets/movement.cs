using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody myRigidbody;
    // Start is called before the first frame update
int turning;
bool going_forward;
bool going_right;
bool going_left;
bool going_back;
bool jumping;
float k_forward;
float k_back;
float k_right;
float k_left;
float k_up;
public float [] k_initial  = {20f,20f,20f,20f,15f};
    void Start()
    {
        turning = 0;
        going_forward=false;
        going_right=false;
        going_left=false;
        going_back=false;
        jumping=false;
        myRigidbody = transform.GetComponent<Rigidbody>();
        k_forward = k_initial[0];
        k_right = k_initial[1];
        k_left = k_initial[2];
        k_back = k_initial[3];
        k_up = k_initial[4];
        
    }
    void getKeyPresses(){
        if(Input.GetKeyDown(KeyCode.W)){
            going_forward = true;
        }else if(Input.GetKeyUp(KeyCode.W)){
            going_forward = false;
        k_forward = k_initial[0];
        }
        if(Input.GetKeyDown(KeyCode.D)){
            going_right =true ;
        }else if(Input.GetKeyUp(KeyCode.D)){
            going_right = false;
        k_right = k_initial[1];
        }
        if(Input.GetKeyDown(KeyCode.A)){
            going_left =true ;
        }else if(Input.GetKeyUp(KeyCode.A)){
            going_left = false;
        k_left = k_initial[2];
        }
        if(Input.GetKeyDown(KeyCode.S)){
            going_back =true ;
        }else if(Input.GetKeyUp(KeyCode.S)){
            going_back = false;
        k_back = k_initial[3];
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            turning = 2;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            turning = 1;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)){
            turning = 0;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
            turning = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            jumping = true;
        }else if(Input.GetKeyUp(KeyCode.Space)){
            jumping=false;
        k_up = k_initial[4];
        }
    }
    float getDecay(float k){
        //float min_val = ;
        return k * 0.99f;
    }
    // Update is called once per frame
    Vector3 clipVec(Vector3 tempVec){
        float newX = tempVec.x;
        float newY = tempVec.y;
        float newZ = tempVec.z;
        if (newX> 4f){
            newX = 4f;
        }
        if (newY> 4f){
            newY = 4f;
        }
        if (newZ> 4f){
            newZ = 4f;
        }
        return new Vector3(newX,newY,newZ);
    }
    void Update()
    {
        getKeyPresses();
        transform.eulerAngles =new Vector3(0, transform.eulerAngles.y,0);
        //Debug.Log(transform.eulerAngles);
        if (turning ==1){
            transform.Rotate(-Vector3.up*0.2f);
        }
        if (turning ==2){
            transform.Rotate(Vector3.up*0.2f);
        }
        if (going_forward){
            //#myRigidbody.velocity = clipVec(myRigidbody.velocity+transform.forward);
            myRigidbody.AddForce(k_forward*transform.forward);
            k_forward = getDecay(k_forward);
        }
        if(going_right){
            //#myRigidbody.velocity = clipVec(myRigidbody.velocity+transform.right);
            myRigidbody.AddForce(k_right*transform.right);
            k_right = getDecay(k_right);

        }
        if(going_left){
            //#myRigidbody.velocity = clipVec(myRigidbody.velocity-transform.right);
            myRigidbody.AddForce(-k_left*transform.right);
            k_left = getDecay(k_left);

        }
        if(going_back){
            //#myRigidbody.velocity = clipVec(myRigidbody.velocity-transform.forward);
            myRigidbody.AddForce(-k_back*transform.forward);
            k_back = getDecay(k_back);

        }
        if (jumping){
            //#myRigidbody.velocity = clipVec(myRigidbody.velocity+Vector3.up);
            myRigidbody.AddForce(k_up*transform.up);
            k_up = getDecay(k_up);

        }
    }
}
