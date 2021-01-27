using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esconde : MonoBehaviour
{
    private Animator CAnimation;
    public Collider2D other;
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("esconde", false);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entrou");
        if(other.tag == "Player") 
        CAnimation.SetBool("esconde", true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("saiu");
        if (other.tag == "playerground")
            CAnimation.SetBool("esconde", false);
    }



}