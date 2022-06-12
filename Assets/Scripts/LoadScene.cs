using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void openGalata(){
        SceneManager.LoadScene("Galata");
    }
    public void openBesiktas(){
        SceneManager.LoadScene("Besiktas");
    }
    public void openKizKulesi(){
        SceneManager.LoadScene("KizKulesi");
    }
    public void openCiragan(){
        SceneManager.LoadScene("Ciragan");
    }
    void OnTriggerEnter(Collider other){
        Debug.Log("Going to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
