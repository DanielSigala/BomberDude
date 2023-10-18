using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropHeart : MonoBehaviour
{
    public GameObject heart;
    public void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "explo"){
            Destroy(gameObject);
            Vector2 position = transform.position;
            GameObject dropGate = Instantiate(heart, position, Quaternion.identity);
        }
}
}
