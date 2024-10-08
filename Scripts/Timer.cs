using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool timeRunning = true;
    public GameObject finalBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRunning){
            elapsedTime += Time.deltaTime;

            string minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
            string seconds = Mathf.Floor(elapsedTime % 60).ToString("00");
            string milliseconds = Mathf.Floor((elapsedTime - Mathf.Floor(elapsedTime)) * 100).ToString("00");

            timerText.text = minutes + ":" + seconds + ":" + milliseconds;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
       timeRunning = false;
    }
}