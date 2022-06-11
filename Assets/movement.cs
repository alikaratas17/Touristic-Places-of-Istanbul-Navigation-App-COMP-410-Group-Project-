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
    void Start()
    {
        turning = 0;
        going_forward=false;
        going_right=false;
        going_left=false;
        going_back=false;
        jumping=false;
        myRigidbody = transform.GetComponent<Rigidbody>();
        
    }
    void getKeyPresses(){
        if(Input.GetKeyDown(KeyCode.W)){
            going_forward = true;
        }else if(Input.GetKeyUp(KeyCode.W)){
            going_forward = false;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            going_right =true ;
        }else if(Input.GetKeyUp(KeyCode.D)){
            going_right = false;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            going_left =true ;
        }else if(Input.GetKeyUp(KeyCode.A)){
            going_left = false;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            going_back =true ;
        }else if(Input.GetKeyUp(KeyCode.S)){
            going_back = false;
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
        }
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
        Debug.Log(transform.eulerAngles);
        if (turning ==1){
            transform.Rotate(-Vector3.up*0.2f);
        }
        if (turning ==2){
            transform.Rotate(Vector3.up*0.2f);
        }
        if (going_forward){
            myRigidbody.velocity = clipVec(myRigidbody.velocity+transform.forward);
        }
        if(going_right){
            myRigidbody.velocity = clipVec(myRigidbody.velocity+transform.right);

        }
        if(going_left){
            myRigidbody.velocity = clipVec(myRigidbody.velocity-transform.right);

        }
        if(going_back){
            myRigidbody.velocity = clipVec(myRigidbody.velocity-transform.forward);

        }
        if (jumping){
            myRigidbody.velocity = clipVec(myRigidbody.velocity+Vector3.up);

        }
    }
}
