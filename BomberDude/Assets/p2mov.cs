using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2mov : MonoBehaviour
{

    PlayerMov movement;

    void Awake(){
        movement = GetComponent<PlayerMov>();
    }


    void FixedUpdate(){
        Vector3 vel = Vector3.zero;
        if(Input.GetKey(KeyCode.UpArrow)){
            vel.y = 1;
        }else if(Input.GetKey(KeyCode.DownArrow)){
            vel.y = -1;
        }else if(Input.GetKey(KeyCode.LeftArrow)){
            vel.x = -1;
        }else if(Input.GetKey(KeyCode.RightArrow)){
            vel.x = 1;
        }
        //movement.MoveTransform(vel);
        movement.MoveTransform(vel);
        // pointsHandler.AddDistance(vel.magnitude * Time.deltaTime);


    }

}