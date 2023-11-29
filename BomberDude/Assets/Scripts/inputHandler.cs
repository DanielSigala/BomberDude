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
        Vector2 vel = Vector2.zero;
        if(Input.GetKey(KeyCode.W)){
            vel.y = 1;
            movement.moveValue = vel;
        }else if(Input.GetKey(KeyCode.S)){
            vel.y = -1;
            movement.moveValue = vel;
        }else if(Input.GetKey(KeyCode.A)){
            vel.x = -1;
            movement.moveValue = vel;
        }else if(Input.GetKey(KeyCode.D)){
            vel.x = 1;
            movement.moveValue = vel;
        }
        //movement.MoveTransform(vel);
        // pointsHandler.AddDistance(vel.magnitude * Time.deltaTime);


    }

}