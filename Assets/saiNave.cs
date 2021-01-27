using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saiNave : MonoBehaviour
{
    // Start is called before the first frame update
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
            CAnimation.SetBool("saida", true);
        }
    }

    void fecha() {  GameObject.FindGameObjectWithTag("alert").GetComponent<abreEscotilha>().ver2 = true;  }

}
