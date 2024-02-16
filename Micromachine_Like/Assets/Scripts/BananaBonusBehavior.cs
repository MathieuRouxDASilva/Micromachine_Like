using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaBonusBehavior : MonoBehaviour
{
    public bool isHit = false;
    private void OnCollisionEnter(Collision other)
    {
        isHit = true;
    }
}
