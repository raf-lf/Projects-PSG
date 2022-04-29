using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    Vector3 touchStart;
    Vector3 touchEnd;
    public Animator indicatorAnim;
    private Vector2 direction;
    public float swipeForce;


    private Vector3 GetTouchPosition()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, -Camera.main.transform.position.z));
    }

    private void TouchStart()
    {
        indicatorAnim.SetBool("touching", true);
        touchStart = GetTouchPosition();


    }

    private void TouchEnd()
    {
        indicatorAnim.SetBool("touching", false);
        touchEnd = GetTouchPosition();
        ExecuteSwipe();
    }
    private void ExecuteSwipe()
    {

        direction = Calculations.GetDirectionToTarget(touchStart, touchEnd);
        GetComponent<Rigidbody2D>().velocity = swipeForce * -direction;
    }


    private void Update()
    {
        if (Input.touchCount > 0)
        {

            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    TouchStart();
                    break;
                case TouchPhase.Ended:
                    TouchEnd();
                    break;
            }


        }
    }
}
