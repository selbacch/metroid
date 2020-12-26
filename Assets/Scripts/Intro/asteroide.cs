using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroide: MonoBehaviour

{
    public float speed;

    private float timeDestroy;
    private float range = 15f;

    void Start()
    {
        if (gameObject.name == "tiro(Clone)")
        {
            timeDestroy = 10f;
            Destroy(gameObject, timeDestroy);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
