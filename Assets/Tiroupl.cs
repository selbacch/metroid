using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiroupl : MonoBehaviour
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
        diagonal.x = -2;
        diagonal.y = 0.1f;

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
        

        if (gameObject.name == "tiroupl(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
            GetComponent<toca>().TocaEfeito1();

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
