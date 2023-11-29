using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] float speed = 1;
    private Rigidbody2D rb2;
    public Vector2 moveValue;

    private void OnMove(InputValue value){
       moveValue = value.Get<Vector2>();
    }
    private void OnUp(){
        Vector2 v = Vector2.zero;
        v.y = 1;
        moveValue = v;
    }
    private void OnDown(){
        Vector2 v = Vector2.zero;
        v.y = -1;
        moveValue = v;
    }
    private void OnLeft(){
        Vector2 v = Vector2.zero;
        v.x = -1;
        moveValue = v;
    }
    private void OnRight(){
        Vector2 v = Vector2.zero;
        v.x = 1;
        moveValue = v;
    }
    void Awake(){
        rb2 = GetComponent<Rigidbody2D>();
    }

    public void MoveTransform(){
        Vector2 result = moveValue * speed;
        rb2.velocity = result;
    }
    private void FixedUpdate(){
        MoveTransform();
    }
}