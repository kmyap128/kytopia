using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public Rigidbody2D Ball;
    public Vector2 leapTargetPos;
    public float leapMagnitude = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            OnLeap();
        }
    }

    // Method called when the left mouse button is released
    public void OnLeap()
    {
        Vector3 mouseScreenPos = Input.mousePosition;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        leapTargetPos = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

        Leap();
    }
    void Leap(){
        Vector2 direction = leapTargetPos - Ball.position;

        Vector2 normalizedDirection = direction.normalized;

        Vector2 force = normalizedDirection * leapMagnitude;
        Ball.AddForce(force, ForceMode2D.Impulse);
    }
}
