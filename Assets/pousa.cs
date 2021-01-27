using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pousa : MonoBehaviour

{
    private Animator CAnimation;
    public bool ver = false;
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
            CAnimation.SetBool("cheguei", true);
        }
    }



    public void Troca() { GameObject.FindGameObjectWithTag("alert").GetComponent<abreEscotilha>().ver = true; }

}