using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mpoint : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;
    public float jump;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("foi1");
        if (other.gameObject.layer == 9)

        {
            Debug.Log("foi2");
            rb.AddForce(transform.up * Speed * jump);

        }
    }
}
