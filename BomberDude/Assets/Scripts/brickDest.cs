using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickDest : MonoBehaviour
{

    public GameObject heart;
    public GameObject bombPlus;
    public GameObject range;
    public void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "explo"){
            Vector2 position = transform.position;
            position.x += .2f;
            
            int randomNumber  = Random.Range(0, 16);
            
            if (randomNumber == 2 || randomNumber == 3){
                GameObject dropHeart = Instantiate(heart, position, Quaternion.identity);
            }
            else if (randomNumber == 4 || randomNumber == 5){
                GameObject dropBombPlus = Instantiate(bombPlus, position, Quaternion.identity);
            }
            else if (randomNumber == 6 || randomNumber == 7){
                GameObject dropRange = Instantiate(range, position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
}
    
}
