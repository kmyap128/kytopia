using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class SliceTracker : MonoBehaviour
{
    public SwipeManager manager;
    public GameObject slicer;
    private Vector3 previousMousePosition;
    private GameObject slice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isActive){
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0; 

            if (previousMousePosition != Vector3.zero)
            {
                CreateSlice(previousMousePosition, mouseWorldPosition);
            }

            previousMousePosition = mouseWorldPosition; 
        }
        else
        {
            previousMousePosition = Vector3.zero; 
            Destroy(slice);

        }
    }

    private void CreateSlice(Vector3 start, Vector3 end)
    {
        Vector3 direction = (end - start).normalized;
        float distance = Vector3.Distance(start, end);

        slice = Instantiate(slicer);

        slice.transform.position = (start + end) / 2;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        slice.transform.rotation = Quaternion.Euler(0, 0, angle);

        BoxCollider2D boxCollider = slice.GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(distance, 0.1f); // Thin width (0.1) and length equal to the drag distance
        boxCollider.isTrigger = true;
    }
}

