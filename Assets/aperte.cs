using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aperte : MonoBehaviour
{
    private Animator CAnimation;
    public bool vira = false;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vira == true)
        {
            CAnimation.SetBool("aperte", true);
        }
    }
}