using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class detectCollision : MonoBehaviour
{
    public int hearts;
    GameObject heartText;
    private heartCounter heartC;
    public GameObject hS;
    public GameObject hurtS;
    public void Start(){
        hearts = 1;
        heartText = GameObject.Find("Hearts");
        heartC = heartText.GetComponent<heartCounter>();
        hS = GameObject.Find("HeartSound");
        hurtS = GameObject.Find("hurtSound");
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "hrt"){
            hS.GetComponent<AudioSource>().Play();
            hearts++;
            heartC.heartCntr.text = hearts.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "explo" || other.gameObject.tag == "bln"){
            hurtS.GetComponent<AudioSource>().Play();
            hearts--;
            heartC.heartCntr.text = hearts.ToString();
            if (hearts <= 0){
                Destroy(gameObject);
                SceneManager.LoadScene("Title");
            }
        }
        if (other.gameObject.tag == "gate"){
            SceneManager.LoadScene("Title");
        }
        
    }
}
