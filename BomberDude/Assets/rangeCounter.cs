using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rangeCounter : MonoBehaviour
{
    public Text rangeAmount;
    void Awake(){
        rangeAmount = GetComponent<Text>();
    }
}
