using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Demo : MonoBehaviour
{
    [SerializeField]
    private int faveNum = 5;
    public Rigidbody2D ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ball.transform.position);
        transform.Translate(1, 1, 1);
    }
}
