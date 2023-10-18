using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickDest : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "explo"){
             Destroy(gameObject);
        }
}
}
