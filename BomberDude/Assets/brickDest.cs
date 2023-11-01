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
            
            int randomNumber  = Random.Range(0, 15);
            
            if (randomNumber == 2){
                GameObject dropHeart = Instantiate(heart, position, Quaternion.identity);
            }
            else if (randomNumber == 4){
                GameObject dropBombPlus = Instantiate(bombPlus, position, Quaternion.identity);
            }
            else if (randomNumber == 6){
                GameObject dropRange = Instantiate(range, position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
}
    
}
