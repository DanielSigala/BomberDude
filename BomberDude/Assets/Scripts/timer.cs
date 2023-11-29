using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    Text timerText;
    int seconds = 300;
    void Start(){
        timerText = GetComponent<Text>();
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine(){
        while(true){
            yield return new WaitForSeconds(1);
            seconds -= 1;
            timerText.text = seconds.ToString();
        }
        yield return null;

    }

    void Update(){
        if (seconds == 0){
            ScoreManager.instance.NextLevelOrMainMenu("GOBM");
        }
    }
}