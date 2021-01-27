using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroupr : MonoBehaviour
{
    public float speed;
    private Animator CAnimation;
    private float timeDestroy;
    private float range = 20f;
    public Collision2D collision;
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("ur", true);
       
    }

    void Update()
    {
        CAnimation.SetBool("ur", true);

        Vector2 diagonal;
        diagonal.x = 2;
            diagonal.y = 0.1f;

       transform.Translate(diagonal * speed * Time.deltaTime);

        if (gameObject.name == "tiroupr(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }

        if (gameObject.name == "missilpr(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (gameObject.name == "tiroupr(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);

            GetComponent<toca>().TocaEfeito1();

        }




        if (gameObject.name == "missilpr(Clone)")
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