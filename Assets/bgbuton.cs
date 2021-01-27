using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgbuton : MonoBehaviour
{
    private Animator CAnimation;
    public bool vira = false;
    private void apertaVai() { GameObject.FindGameObjectWithTag("button").GetComponent<aperte>().vira = true; }
}
