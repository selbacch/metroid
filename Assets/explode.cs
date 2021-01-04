using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explode : MonoBehaviour
{
    public string cena;
    public float cronometro;
   public  Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= 0.2f) { myLight.intensity = 3; }

        if (cronometro >= 0.4f) { myLight.intensity = 4; }
        if (cronometro >= 0.6f) { myLight.intensity = 15; }
        if (cronometro >= 0.8f) { myLight.intensity = 50; }

        if (cronometro>= 1.047834f)
            {
            myLight.intensity = 5000000000;

        }

        if(cronometro>= 1.507563)
        {

            float timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);
            SceneManager.LoadScene(cena);
        }
    }
}
