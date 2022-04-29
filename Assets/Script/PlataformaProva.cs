using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaProva : MonoBehaviour
{
    public bool moveStarted;
    public float distanceToMove = 6;
    public float movementDuration = 3;
    private float startTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !moveStarted)
        {
            moveStarted = true;
            StartCoroutine(Movement());
        }

    }

    private IEnumerator Movement()
    {
        startTime = Time.time;
        float distancePerSecond = distanceToMove / movementDuration;

        while (Time.time < startTime + movementDuration)
        {
            transform.Translate(new Vector3(distancePerSecond * Time.deltaTime, 0, 0));
            yield return new WaitForEndOfFrame();
        }

        moveStarted = false;

    }
}
