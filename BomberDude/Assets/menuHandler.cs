using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuHandler : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("MAP1");
    }

    public void QuitGame(){
        Application.Quit(); //this does not work in the editor
    }
}
