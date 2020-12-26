using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atiraasteroide : MonoBehaviour
{
    public GameObject tiro;
    public Transform point;
    public float cronometro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cronometro += Time.deltaTime;

        if (cronometro >= 6)
        {
            GameObject CloneTiro = Instantiate(tiro, point.position, point.rotation);

    }   }
}
