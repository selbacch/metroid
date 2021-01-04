using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class autodestruct : MonoBehaviour
{

    public float timer = 5;
    // Start is called before the first frame update

  




        float oldTimer;
        bool isRunning = true;
    public bool ver;
        void Start()
        {
            oldTimer = timer;
        }

        // Update is called once per frame
        void Update()
        {
        // ver = GameObject.FindGameObjectWithTag("Text").GetComponent<autodestruct>().ver;
        Debug.Log(ver);
        if (ver == true)
        {
            
                timer -= Time.deltaTime;
                GetComponent<Text>().text = "Tempo: " + Mathf.RoundToInt(timer).ToString("0:00") + " s";

                if (timer < 0)
                    isRunning = false;
            }
        if(timer<=0) SceneManager.LoadScene("seresDeath");
    }

    
}
