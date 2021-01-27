using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
    
{
    public float dano = 1;
    public float speed;
    public Collision2D alvo;
    private float timeDestroy;
    private float range = 20f;
    private Animator CAnimation;
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        if (gameObject.name == "missil(Clone)") {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
        CAnimation = GetComponent<Animator>();
        if (gameObject.name == "tiro(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }




   void OnCollisionEnter2D(Collision2D collision)  {
    
        
        if (gameObject.name == "missil(Clone)")
        {
            CAnimation.SetBool("destroi", true);
            
           
        }
        if (gameObject.name == "tiro(Clone)")
        {
            GetComponent<toca>().TocaEfeito1();
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
        }
    }
    void destroi()
    {
        timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);
    }

}