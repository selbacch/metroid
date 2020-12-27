using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro1 : MonoBehaviour

{
    public float speed;
    public Collider2D collide;
    private float timeDestroy;
    private float range = 20f;

    void Start()
    {
        if (gameObject.name == "tiro1(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
    }

   



    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}