using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class detectCollisionP2 : MonoBehaviour
{
    public int hearts;
    GameObject heartText;
    private heartCounter heartC;
    public GameObject hS;
    public GameObject hurtS;

    GameObject bomber;
    private bombDropperP2 bombD;

    public void Start(){
        heartText = GameObject.Find("Hearts2");
        heartC = heartText.GetComponent<heartCounter>();
        hS = GameObject.Find("HeartSound");
        hurtS = GameObject.Find("hurtSound");
        heartC.heartCntr.text = hearts.ToString();
        bomber = GameObject.Find("bomberchick(Clone)");
        bombD =  bomber.GetComponent<bombDropperP2>();
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "hrt"){
            hS.GetComponent<AudioSource>().Play();
            hearts++;
            heartC.heartCntr.text = hearts.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "bp"){
            hS.GetComponent<AudioSource>().Play();
            bombD.bombsLeft += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "rp"){
            hS.GetComponent<AudioSource>().Play();
            bombD.exploRange += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "explo" || other.gameObject.tag == "bln"){
            hurtS.GetComponent<AudioSource>().Play();
            hearts--;
            heartC.heartCntr.text = hearts.ToString();
            if (hearts <= 0){
                 Invoke("GameOver", 1.5f);
            }
        }
        if (other.gameObject.tag == "gate"){
            SceneManager.LoadScene("Title");
        }
        
    }

    private void GameOver(){
        SceneManager.LoadScene("GOBG");
    }
}
