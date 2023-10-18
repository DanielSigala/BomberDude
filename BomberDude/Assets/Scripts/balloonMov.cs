using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balloonMov : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Rigidbody2D rb;
    GameObject pointsText;
    private pointsUpdate points;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        MoveTransform(1);
    }

    void Start(){
       pointsText = GameObject.Find("Points");
       points = pointsText.GetComponent<pointsUpdate>();
    }
    public void MoveTransform(int x){
        Vector3 vel = Vector3.zero;
        vel.x = x;
        rb.velocity = vel * speed;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "explo"){
            int pText = int.Parse(points.points.text);
            pText += 50;
            points.points.text = pText.ToString();
            Destroy(gameObject);
        }
        
        rb.velocity = -(rb.velocity);

    }
}
