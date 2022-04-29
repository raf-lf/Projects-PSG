using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeProva : MonoBehaviour
{
    private bool clickingOver;
    private bool slinging;
    private Vector3 touchStartPosition;
    private Vector3 touchEndPosition;
    public float shotSpeed = 100;

    private void OnMouseDown()
    {
        clickingOver = true;

    }

    private void OnMouseUp()
    {
        clickingOver = false;
    }

    private Vector3 GetTouchPosition()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, -Camera.main.transform.position.z));
    }

    private Vector2 GetDirectionToTarget(Vector2 origin, Vector2 target)
    {
        Vector2 midPoint = target - origin;
        float distance = midPoint.magnitude;
        Vector2 direction = midPoint / distance;
        direction.Normalize();

        return direction;

    }

    private void SlingReady()
    {
        touchStartPosition = transform.position;
        slinging = true;

    }

    private void SlingShoot()
    {
        if (slinging)
        {
            slinging = false;
            touchEndPosition = GetTouchPosition();

            Vector2 direction = GetDirectionToTarget(touchStartPosition, touchEndPosition);

            GetComponent<Rigidbody2D>().AddForce(shotSpeed * direction * -1);
        }

    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    if(clickingOver)
                        SlingReady();
                    break;
                case TouchPhase.Ended:
                    SlingShoot();
                    break;

            }
        }
    }
}
