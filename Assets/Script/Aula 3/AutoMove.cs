using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private bool stop;
    public Transform birbTransform;

    private void Start()
    {
        Birb.birbDeathEvent += GameOver;
    }

    void GameOver()
    {
        stop = true;

    }

    void Update()
    {
        if (!stop)
        {
            transform.position = new Vector3(birbTransform.position.x, 0, transform.position.z);
        }
    }
}
