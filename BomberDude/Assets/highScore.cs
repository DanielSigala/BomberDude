using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class highScore : MonoBehaviour
{
    Text hs;

    void Start()
    {
        hs = GetComponent<Text>();
        hs.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        hs.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
