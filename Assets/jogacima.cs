using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogacima : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D collider;
    public float speed;
    public float altura;
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.tag == "Player")
        {
            
            rb.AddForce(transform.up * speed * altura);
            GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed * altura);
        }



    }
}
