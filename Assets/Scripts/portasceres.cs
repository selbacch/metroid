using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portasceres : MonoBehaviour
{

    private Collider2D Target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "Player")
        {

            
            // More on game controller shortly.
            Debug.Log("foi");

        }





    }
       





}
