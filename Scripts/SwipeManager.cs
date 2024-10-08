using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeManager : MonoBehaviour
{
    public GameObject cursor;
    public Vector3 mousePosition;
    public Boolean isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set z to 0 since this is 2D
        cursor.transform.position = mousePosition;
        
        // Check if the left mouse button is held down
        if (Input.GetMouseButtonDown(0))
        {
            isActive = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isActive = false;
        }

    }
}
