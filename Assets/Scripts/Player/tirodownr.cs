using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirodownr : MonoBehaviour
{
    public float speed;
    private Animator CAnimation;
    private float timeDestroy;
    private float range = 20f;
    public Collision2D collision;
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("dr", true);
       
    }

    void Update()
    { if (gameObject.name == "tirodownr(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
        if (gameObject.name == "missildr(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
        Vector2 diagonal;
        diagonal.x = 1;
        diagonal.y = -1f;

        transform.Translate(diagonal * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<toca>().TocaEfeito1();

        if (gameObject.name == "tirodownr(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);

        }
       if(gameObject.name == "missildr(Clone)")
        {
            CAnimation.SetBool("destroi", true);


        }


    }

    void destroi()
    {
        timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);
    }
}