using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro1 : MonoBehaviour

{
    private Animator CAnimation;
    public float dano = 1;
    public float speed;
    public Collider2D collide;
    private float timeDestroy;
    private float range = 20f;
    public Collision2D collision;
    void Start()
        
    {
        CAnimation = GetComponent<Animator>();
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



    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<toca>().TocaEfeito1();
        
        if (gameObject.name == "tiro1(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);

        }

        if (gameObject.name == "missil(Clone)")
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