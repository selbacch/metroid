using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirodownjs : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
