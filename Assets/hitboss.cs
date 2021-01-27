using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboss : MonoBehaviour
{
    public GameObject inimigo;
    public float dano;
    public float dano2;
    public bool hit;    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "tiro1")
        {
            hit = true;
            inimigo.GetComponent<Health>().DamagePlayer(dano);



        }
        if (other.tag == "missil")
        {
            hit = true;
            inimigo.GetComponent<Health>().DamagePlayer(dano2);

        }



    }
}
