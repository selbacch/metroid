using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiiroupl : MonoBehaviour
{
    public float speed;
    private Animator CAnimation;
    private float timeDestroy;
    private float range = 20f;

    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("lr", true);
       
    }

    void Update()
    {

        Vector2 diagonal;
        diagonal.x =-1;
        diagonal.y = 0.5f;

        transform.Translate(diagonal * speed * Time.deltaTime);
        if (gameObject.name == "tiroupl(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }

        if (gameObject.name == "missilpl(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<toca>().TocaEfeito1();

        if (gameObject.name == "tiroupl(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);


        }




        if (gameObject.name == "missilpl(Clone)")
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
