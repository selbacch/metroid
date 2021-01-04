using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogo : MonoBehaviour
{ 
 ParticleSystem system
{
    get
        {
            if (_CachedSystem == null)
                _CachedSystem = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
            return _CachedSystem;
        }

    }

    private ParticleSystem _CachedSystem;

public bool includeChildren = true;



public void start()
{
        system.gameObject.tag = "Ridley";
        system.Play(includeChildren);

}


public void stop()
{

    system.Stop(includeChildren);

}
}