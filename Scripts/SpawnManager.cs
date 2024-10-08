using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Ball;
    public GameObject newBall;
    public GameObject Camera;
    public Follow followComponent;
    // Start is called before the first frame update
    void Start()
    {
        newBall = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (newBall == null)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        newBall = Instantiate(Ball, transform.position, Quaternion.identity);
        newBall.tag = "Ball";
        followComponent = newBall.GetComponent<Follow>();
        followComponent.target = newBall;
        followComponent.follower = Camera;
    }
}
