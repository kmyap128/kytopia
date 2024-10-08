using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlushTrigger : MonoBehaviour
{
    private Boolean inWater = false;
    public GameObject Pool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inWater){
            Vector3 currentScale = Pool.transform.localScale;
            currentScale.y -= 0.05f;
            Pool.transform.localScale = currentScale;
            Pool.transform.position -= new Vector3(0, 0.025f, 0);

            if (currentScale.y <= 0)
            {
                Destroy(Pool); 
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
       inWater = true;
    }
}
