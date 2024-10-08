using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject follower;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 followerPos = follower.transform.position; 

        followerPos.x = target.transform.position.x;
        followerPos.y = target.transform.position.y;

        follower.transform.position = followerPos; 
    }
}
