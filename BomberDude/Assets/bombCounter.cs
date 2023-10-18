using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bombCounter : MonoBehaviour
{
    public Text bombAmount;
    void Awake(){
        bombAmount = GetComponent<Text>();
    }
}
