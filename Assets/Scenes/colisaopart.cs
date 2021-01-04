using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisaopart : MonoBehaviour
{
   public GameObject other;
    public float Ridley0;
    public Health playerHealth;
    void OnParticleCollision(GameObject other) {
        
        if (other.tag == "Player")
        {
            
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            
            Ridley0 = GameObject.FindGameObjectWithTag("Ridley").GetComponent<Ridley>().dano;
            playerHealth.DamagePlayer(Ridley0);
            Debug.Log(Ridley0);
        }

    }
}
