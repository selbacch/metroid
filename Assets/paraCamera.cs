using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void onTriggerEnter(Collider2D other)
    {
        if(other.tag == "Player")
            GameObject.FindGameObjectWithTag("paracamera").GetComponent<EdgeCollider2D>().gameObject.SetActive(false);

    }

    void onTriggerExit(Collider2D other)
    {

        Debug.Log("trava");
        if (other.tag == "MainCamera")
            GameObject.FindGameObjectWithTag("paracamera").GetComponent<EdgeCollider2D>().gameObject.SetActive(true);

    }




}
