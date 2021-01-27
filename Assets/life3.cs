using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life3 : MonoBehaviour
{
    public float life;
    public float qtd;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        life = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().curHealth;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag == "Player")
        {

            float timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
        }

    }
    void OnDestroy()
    {
       
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().curHealth= life +qtd;


    }


}

