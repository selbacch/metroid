using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liberadenro : MonoBehaviour
{
    public Collider2D other;
    private Animator CAnimation;
    public string trava;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
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
            GameObject.Find(trava).GetComponent<redpotal>().ver = 0;
            
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "Player")
        {
            CAnimation.SetBool("fecha", true);
            CAnimation.SetBool("abre", false);
            GameObject.Find(trava).GetComponent<redpotal>().ver= 2;
        }
    }
}