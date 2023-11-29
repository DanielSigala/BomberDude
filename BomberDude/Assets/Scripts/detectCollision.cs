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

    GameObject bomber;
    private bombDropper bombD;

    public void Start(){
        heartText = GameObject.Find("Hearts");
        heartC = heartText.GetComponent<heartCounter>();
        hS = GameObject.Find("HeartSound");
        hurtS = GameObject.Find("hurtSound");
        heartC.heartCntr.text = hearts.ToString();
        bomber = GameObject.Find("bomber(Clone)");
        bombD =  bomber.GetComponent<bombDropper>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.isTrigger)
        {
            if (collision.gameObject.tag == "bln"){
            hurtS.GetComponent<AudioSource>().Play();
            hearts--;
            heartC.heartCntr.text = hearts.ToString();
            if (hearts <= 0){
                ScoreManager.instance.NextLevelOrMainMenu("GOBM");
            }
            }
        }
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
                Invoke("GameOver", 1f);
            }
        }
        if (other.gameObject.tag == "gate"){
            ScoreManager.instance.NextLevelOrMainMenu("MAP2");
        }
         if (other.gameObject.tag == "gate2"){
            ScoreManager.instance.NextLevelOrMainMenu("MAP3");
        }
        if (other.gameObject.tag == "gate3"){
            ScoreManager.instance.NextLevelOrMainMenu("TITLE");
        }
        
    }

    private void GameOver(){
        ScoreManager.instance.NextLevelOrMainMenu("GOBM");
    }
}
