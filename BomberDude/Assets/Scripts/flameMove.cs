using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flameMove : MonoBehaviour
{


    GameObject pointsText;
    private pointsUpdate points;
    public GameObject explS;
    public float moveForce = 10f;  // Adjust the force applied
    public float straightMoveDuration = 2f;  // Time duration for straight movement
    public float changeDirectionTime = 2f;  // Time interval to change direction

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isMovingStraight = true;
    private float directionTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("RandomizeMovement", 0f, changeDirectionTime);
        pointsText = GameObject.Find("Points");
       points = pointsText.GetComponent<pointsUpdate>();
       explS = GameObject.Find("enemydown");
       
    }

    void Update()
    {
        directionTimer += Time.deltaTime;

        if (isMovingStraight && directionTimer >= straightMoveDuration)
        {
            isMovingStraight = false;
            directionTimer = 0f;
        }
        else if (!isMovingStraight && directionTimer >= changeDirectionTime)
        {
            isMovingStraight = true;
            directionTimer = 0f;
        }
    }

    void RandomizeMovement()
    {
        if (isMovingStraight)
        {
            // Move straight in a single direction (e.g., right)
            movement = Vector2.left;
        }
        else
        {
            // Generate random direction (left, right, up, down)
            int direction = Random.Range(0, 4);
            switch (direction)
            {
                case 0:
                    movement = Vector2.left;
                    break;
                case 1:
                    movement = Vector2.right;
                    break;
                case 2:
                    movement = Vector2.up;
                    break;
                case 3:
                    movement = Vector2.down;
                    break;
                default:
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * moveForce * Time.fixedDeltaTime);
    }

 

  
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "explo"){
            explS.GetComponent<AudioSource>().Play();
            int pText = int.Parse(points.points.text);
            pText += 150;
            int additionalPoints = 150; 
            ScoreManager.instance.UpdateScore(additionalPoints);
            points.points.text = pText.ToString();
            Destroy(gameObject);
        }
        
        rb.velocity = -(rb.velocity);

    }
}

