using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirodownl : MonoBehaviour
{
    private Animator CAnimation;
    public float speed;
    public Collision2D collision;
    private float timeDestroy;
    private float range = 20f;

    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("dl", true);
        
    }

    void Update()
    {
        if (gameObject.name == "tirodownl(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
        if (gameObject.name == "missildl(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
        Vector2 diagonal;
        diagonal.x = -1;
        diagonal.y = -0.1f;

        transform.Translate(diagonal * speed * Time.deltaTime);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (gameObject.name == "tirodownl(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
            GetComponent<toca>().TocaEfeito1();

        }




       if(gameObject.name == "missildl(Clone)")
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
