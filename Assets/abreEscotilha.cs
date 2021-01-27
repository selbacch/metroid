using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abreEscotilha : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator CAnimation;
    public bool ver = false;
    public bool ver2 = false;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ver == true)
        {
            CAnimation.SetBool("abre", true);
        }

        if (ver2 == true)
        {
            CAnimation.SetBool("fecha", true);
        }


    }

    void desliga() { GameObject.FindGameObjectWithTag("Renderizador").GetComponent<pousa>().ver = true; }
    void saindo()
    {

         GameObject.FindGameObjectWithTag("Fogo").GetComponent<saiNave>().ver = true;

    }


   

}
