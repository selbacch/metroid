using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedra : MonoBehaviour
{
    public GameObject pedras;
    public float cronometro;
    public bool cronos = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cronos = true)
        {
            cronometro += Time.deltaTime;

            if(cronometro >= 10f)
            {
                pedras.SetActive(true);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "tiro1")
        {
            pedras.SetActive(false);
            cronos = true;

        }


    }




}
