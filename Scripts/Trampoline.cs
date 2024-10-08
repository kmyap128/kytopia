using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f;
    public Vector2 bounceDirection = new Vector2(0, 1);  


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 normalizedBounceDirection = bounceDirection.normalized;

            rb.velocity = new Vector2(rb.velocity.x * (1 - Mathf.Abs(normalizedBounceDirection.x)),
                                      rb.velocity.y * (1 - Mathf.Abs(normalizedBounceDirection.y)));

            rb.AddForce(normalizedBounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
