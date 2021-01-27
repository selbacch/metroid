using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawtrigger : MonoBehaviour
{
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject enemy8;
    public GameObject enemy9;
    public GameObject enemy10;
    public GameObject enemy11;
    public GameObject enemy12;
    public GameObject enemy13;
    public GameObject enemy14;
    public GameObject enemy15;
    public GameObject enemy16;

    // Start is called before the first frame update
    void Start()
    {
        enemy16.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        enemy0.SetActive(true);
        enemy1.SetActive(true);
        enemy2.SetActive(true);
        enemy3.SetActive(true);
        enemy4.SetActive(true);
        enemy5.SetActive(true);
        enemy6.SetActive(true);
        enemy7.SetActive(true);
        enemy8.SetActive(true);
        enemy9.SetActive(true);
        enemy10.SetActive(true);
        enemy11.SetActive(true);
        enemy12.SetActive(true);
        enemy13.SetActive(true);
        enemy14.SetActive(true);
        enemy15.SetActive(true);





    }




    }
