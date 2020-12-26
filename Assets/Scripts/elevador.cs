using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevador : MonoBehaviour
{
    [HideInInspector] public AnimationController ac;
    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AnimationController>() ?? null;
        ac.PlayAnimation(0);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
