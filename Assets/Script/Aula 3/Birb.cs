using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class Birb : MonoBehaviour
{
    private Rigidbody2D rb;
    public TapGesture gesture;
    public float flapForce;
    public float moveForce;
    public GameObject vfxDeath;
    public GameObject vfxFlap;

    public delegate void BirbDead();
    public static event BirbDead birbDeathEvent;

    public void Death()
    {
        if (birbDeathEvent != null)
        {
            birbDeathEvent();

            GameObject deathVfx = Instantiate(vfxDeath);
            deathVfx.transform.position = transform.position;

            gameObject.SetActive(false);
        }

    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnEnable()
    {
        gesture.Tapped += Flap; // Inscreve o objeto
    }

    private void OnDisable()
    {
        gesture.Tapped -= Flap; // Cancela a inscrição o objeto

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death();
    }

    public void FlapExecute()
    {
        rb.AddForce(Vector2.up * flapForce);
        GameObject flapVfx = Instantiate(vfxFlap);
        flapVfx.transform.position = transform.position;

    }
    public void Flap(object sender, System.EventArgs e)
    {
        FlapExecute();

    }

    private void Update()
    {
        rb.velocity = new Vector2(moveForce, rb.velocity.y);

        /* if (Input.GetMouseButtonDown(0))
         {
             Flap();
         }
        */
    }
}
