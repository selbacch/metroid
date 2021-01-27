using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroup : MonoBehaviour
{
    private Animator CAnimation;
    public float speed;
    
    private float timeDestroy;
    private float range = 20f;
    public Collision2D collision;
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("up", true);
        if (gameObject.name == "tiroup(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (gameObject.name == "tiroup(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
            GetComponent<toca>().TocaEfeito1();

        }
       if(gameObject.name == "missil(Clone)")
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
