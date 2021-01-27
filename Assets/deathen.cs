using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathen : MonoBehaviour
{
    public GameObject inimigo;
    public bool ativa = false;
    private Animator CAnimation;
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ativa == true) { CAnimation.SetBool("death", true); };


    }
    void morreu()
    {
        inimigo.SetActive(false);
        CAnimation.SetBool("death", false);
    }
}
