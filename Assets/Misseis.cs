using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misseis : MonoBehaviour
{

    public int qtd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ms.misseis = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().municao(qtd);


    }


}
