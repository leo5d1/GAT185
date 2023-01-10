using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int travelFrames;

    private void Awake()
    {
        travelFrames = 0;
    }

    void Update()
    {
        if (gameObject)
        {
            transform.position += Vector3.forward;
            travelFrames++;
            if (travelFrames >= 40) { Destroy(gameObject); }
        }
        
    }
}
