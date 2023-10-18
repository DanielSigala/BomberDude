using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateBrick : MonoBehaviour
{
    public GameObject gate;
    public void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "explo"){
            Destroy(gameObject);
            Vector2 position = transform.position;
            GameObject dropGate = Instantiate(gate, position, Quaternion.identity);
        }
}
}