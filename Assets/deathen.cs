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
        if (ativa == true) { morreu(); }


    }
    void morreu()
    {
        inimigo.SetActive(false);
        
    }
}
