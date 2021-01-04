using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portasceres : MonoBehaviour
{
    public GameObject porta;
    private Animator CAnimation;
    public Collider2D collider;
    public string trava;
    public bool aciona = false;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        trava = porta.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void desativa()
    {
        this.transform.Find(trava).GetComponent<BoxCollider2D>().gameObject.SetActive(false);
        
    }
    void ativa()
    {
        this.transform.Find(trava).GetComponent<BoxCollider2D>().gameObject.SetActive(true);

    }



    void OnTriggerStay2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "Player" && aciona == false)
        {

            Debug.Log(aciona);
            CAnimation.SetBool("abre", true);
           
            
        }

    }


    void OnTriggerExit2D(Collider2D collider)
    {
        // If the player hits the trigger.
        if (collider.gameObject.tag == "Player" )
        {

           
            CAnimation.SetBool("abre", false);
           
        }

    }




}
