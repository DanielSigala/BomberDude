using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsUpdate : MonoBehaviour
{
    public Text points;
    void Awake(){
        points = GetComponent<Text>();
    }
}
