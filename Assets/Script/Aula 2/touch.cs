using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class touch : MonoBehaviour
{
    public Touch touchId;
    public Text touchCounter;
    public GameObject moveableObject;
    public GameObject spawnedObject;

    void Update()
    {
        if (Input.touchCount >0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                touchId = Input.GetTouch(i);
                Debug.Log("Touch " + i + "at " + Input.GetTouch(i).position);

                Vector3 cameraPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, -Camera.main.transform.position.z);

                moveableObject.transform.position = Camera.main.ScreenToWorldPoint(cameraPosition);

                if (touchId.phase == TouchPhase.Ended)
                {
                    GameObject spawn = Instantiate(spawnedObject);
                    spawn.transform.position = Camera.main.ScreenToWorldPoint(cameraPosition);
                }
            }

        }
    }
}
