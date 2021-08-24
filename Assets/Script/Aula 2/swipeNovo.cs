using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeNovo : MonoBehaviour
{
    private float timer;
    Vector3 touchStart;
    Vector3 touchEnd;

    private Vector2 direction;
    public float swipeForce;


    private Vector3 GetTouchPosition()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, -Camera.main.transform.position.z));
    }

    private void TouchStart()
    {
        timer = 0;
        touchStart = transform.position;


    }

    private void TouchEnd()
    {
        touchStart = GetTouchPosition();
        Debug.Log(GetTouchPosition());
        ExecuteSwipe();
    }
    private void ExecuteSwipe()
    {
        //GameObject sparkles = Instantiate(sparklesPrefab);
        //sparkles.transform.position = transform.position;

        direction = Calculations.GetDirectionToTarget(touchStart, touchEnd);

        GetComponent<Rigidbody2D>().velocity = (touchEnd - touchStart) * -direction;
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    TouchStart();
                    break;
                case TouchPhase.Ended:
                    break;


            }
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                TouchEnd();
            }

        }
    }
}
