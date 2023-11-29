using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoMenu : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadMenu", 18f);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Title");
    }
}
