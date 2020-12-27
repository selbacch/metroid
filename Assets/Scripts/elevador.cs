using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevador : MonoBehaviour
{
    private Animator CAnimation;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("decendo", true);
    }



     void stopelevador()
    {
        CAnimation.SetBool("decendo", false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
