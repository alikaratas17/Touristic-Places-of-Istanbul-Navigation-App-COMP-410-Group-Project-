using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody myRigidbody;
    // Start is called before the first frame update
int turning;
    void Start()
    {
        turning = 0;
        myRigidbody = transform.GetComponent<Rigidbody>();
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles =new Vector3(0, transform.eulerAngles.y,0);
        if(Input.GetKeyDown(KeyCode.W)){
            myRigidbody.AddForce(transform.forward*200f);
            transform.Rotate(-Vector3.up*0.2f);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            myRigidbody.AddForce(transform.right*200f);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            myRigidbody.AddForce(-transform.right*200f);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            myRigidbody.AddForce(-transform.forward*200f);
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
            myRigidbody.AddForce(Vector3.up*50f);
        }
        if (turning ==1){
            transform.Rotate(-Vector3.up*0.2f);
        }
        if (turning ==2){
            transform.Rotate(Vector3.up*0.2f);
        }
    }
}
