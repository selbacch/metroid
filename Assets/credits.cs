using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    private Animator CAnimation;
    public bool ativa;
    // Start is called before the first frame update
    void Start()
    {
        ativa = false;
        CAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ativa == true)
        {
            CAnimation.SetBool("creditos", true);

        }
        else { CAnimation.SetBool("creditos", false); }


    }

    void creditend() {
        ativa = false;

    }
}
