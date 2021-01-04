using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contecao : MonoBehaviour
{
    
    public Health playerHealth;
    public Health ridleyHealth;
    void Update() { destrucCeres(); }

    void  destrucCeres() {

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        ridleyHealth = GameObject.FindGameObjectWithTag("Ridley").GetComponent<Health>();
        




        if (playerHealth.curHealth <= 20f || ridleyHealth.curHealth <= 60f) {
            Debug.Log("faleceu aqui");
            GameObject.FindGameObjectWithTag("Ridley").GetComponent<Ridley>().death();
        }
    }
}
