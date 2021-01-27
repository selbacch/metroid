using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevadorbrain : MonoBehaviour
{
    public KeyCode ActionKey = KeyCode.W;
    public Collider2D other;
    private Animator CAnimation;
    private bool ativa;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        ativa = false;
    }



    void stopelevador()
    {
        CAnimation.SetBool("descendo", false);
        CAnimation.SetBool("subindo", false);

    }
    // Update is called once per frame
    void Update()
    {


    }



    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag=="Player")
        {
            if (ativa==true) {
                CAnimation.SetBool("subindo", true);
                ativa = false; }

            if (ativa == false)
            {
                CAnimation.SetBool("descendo", true);
                ativa = true;
            }


        }
       

    }
    


}

