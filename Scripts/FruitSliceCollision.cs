using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSliceCollision : MonoBehaviour
{
    private bool hasEntered = false;
    private bool hasExited = false;
    public GameObject slicer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D slicer)
    {
        hasEntered = true; 
        Debug.Log("Slice entered the fruit!");

    }

    private void OnTriggerExit2D(Collider2D slicer)
    {
        hasExited = true; 
        Debug.Log("Slice exited");

        if (hasEntered && hasExited)
        {
            Debug.Log("Fruit fully sliced");
            Destroy(gameObject);  
        }
    }
}
