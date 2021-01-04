using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giramapa : MonoBehaviour
{
    public bool roda = false;

    public float cronometro;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameObject.FindGameObjectWithTag("autodestroy").GetComponent<autodestruct>().ver != false && roda ==true)
        {
            cronometro += Time.deltaTime;
            if (cronometro >= 20f) { transform.rotation = Quaternion.Euler(0, 0, 2); }
            if (cronometro >= 10f)
            {
                transform.rotation = Quaternion.Euler(0, 0, -2);
            }
            if (cronometro <= 9f) { transform.rotation = Quaternion.Euler(0, 0, 0); }
            if (cronometro >= 21f) {cronometro = 0;
        }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            roda = false;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            roda = true;
        }

    }

}
