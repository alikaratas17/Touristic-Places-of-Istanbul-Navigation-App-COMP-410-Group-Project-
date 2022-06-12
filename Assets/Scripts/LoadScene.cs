using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void openNextScene(){
        Debug.Log("Going to Main Menu");
        SceneManager.LoadScene("MainMenu");

    }
    void OnTriggerEnter(Collider other){
        openNextScene();
    }
}
