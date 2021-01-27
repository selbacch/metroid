using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitenemi : MonoBehaviour
{
    public float tiro;
    public Health enemy;
    public bool hit = false;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "tiro1")
        {
            hit = true;
            enemy = GameObject.FindGameObjectWithTag("Ridley").GetComponent<Health>();
            
            tiro = GameObject.FindGameObjectWithTag("Ridley").GetComponent<Ridley>().dano;
            enemy.DamagePlayer(tiro);

        }
        if (other.tag == "missil")
        {
            hit = true;
            enemy = GameObject.FindGameObjectWithTag("Ridley").GetComponent<Health>();

            tiro = GameObject.FindGameObjectWithTag("Ridley").GetComponent<Ridley>().dano;
            enemy.DamagePlayer(tiro);

        }




        void hitoff(){ hit = false; }
    }
}
