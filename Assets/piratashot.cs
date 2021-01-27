using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piratashot : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public Transform point;
    private float timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "piratashot(Clone)")
        {
            timeDestroy = 5f;
            Destroy(gameObject, timeDestroy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
       
    }


      
void OnCollisionEnter2D(Collision2D collision)
{
   

    if (gameObject.name == "piratashot(Clone)")
    {
        timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);

    }

}


}

