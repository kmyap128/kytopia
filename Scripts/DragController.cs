using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragController : MonoBehaviour
{
    public RandomSpawnManager spawnManager;
    public float spawnDistance = 0.1f;
    private Vector2 previousPos; 
    private float totalDistance = 0f;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
            totalDistance = 0f;
        }

        if(isActive)
        {
            mouseDrag();
        }
    }

    void mouseDrag(){
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (totalDistance == 0f)
        {
            previousPos = currentPos;
        }

        float distanceTraveledThisFrame = Vector2.Distance(previousPos, currentPos);

        totalDistance += distanceTraveledThisFrame;
        Debug.Log(totalDistance);
        if (totalDistance >= spawnDistance)
        {
            spawnManager.Spawn(currentPos.x, currentPos.y, 0);

            totalDistance = 0f;
            previousPos = currentPos;
        }
        else
        {
            previousPos = currentPos;
        }
    }
}
