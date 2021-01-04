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

    void Start()
    {
        if (gameObject.name =="tiro(Clone)") {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }




   void OnCollisionEnter2D(Collision2D collision)  {
    GetComponent<toca>().TocaEfeito1();
        
        if (gameObject.name == "tiro(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
           
        }
    }


}