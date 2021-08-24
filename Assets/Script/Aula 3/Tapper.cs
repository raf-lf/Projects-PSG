using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapper : MonoBehaviour
{

    public void Tapped()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
    
}
