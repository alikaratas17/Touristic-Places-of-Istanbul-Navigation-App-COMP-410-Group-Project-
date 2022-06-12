using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void openNextScene(){
        Debug.Log("Activated");
        //SceneManager.LoadScene("");

    }
    void OnTriggerEnter(Collider other){
        openNextScene();
    }
}
