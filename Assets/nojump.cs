using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nojump : MonoBehaviour
{
    public GameObject trava;
    public GameObject joga;
    private Animator CAnimation;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();

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
                  
            joga.SetActive(false);
           trava.SetActive(false);
          
        }

        




    }
}