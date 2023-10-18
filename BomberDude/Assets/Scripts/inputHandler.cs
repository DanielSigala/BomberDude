using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandler : MonoBehaviour
{

    PlayerMov movement;

    void Awake(){
        movement = GetComponent<PlayerMov>();
    }


    void FixedUpdate(){
        Vector3 vel = Vector3.zero;
        if(Input.GetKey(KeyCode.W)){
            vel.y = 1;
        }else if(Input.GetKey(KeyCode.S)){
            vel.y = -1;
        }else if(Input.GetKey(KeyCode.A)){
            vel.x = -1;
        }else if(Input.GetKey(KeyCode.D)){
            vel.x = 1;
        }
        //movement.MoveTransform(vel);
        movement.MoveTransform(vel);
        // pointsHandler.AddDistance(vel.magnitude * Time.deltaTime);


    }

}