using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiiroupl : MonoBehaviour
{
    public float speed;

    private float timeDestroy;
    private float range = 20f;

    void Start()
    {
        if (gameObject.name == "tiro(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
    }

    void Update()
    {
       // transform.Translate(Vector2.x * -1 + Vector2.y * speed * Time.deltaTime);
    }
}
