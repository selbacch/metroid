﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirodownjs : MonoBehaviour
{
    public float speed;
    private Animator CAnimation;
    private float timeDestroy;
    private float range = 20f;
    public Collision2D collision;
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("down", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (gameObject.name == "tirojsdown(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }

        if (gameObject.name == "missild(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (gameObject.name == "tirojsdown(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);

            GetComponent<toca>().TocaEfeito1();
        }




       if(gameObject.name == "missild(Clone)")
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
