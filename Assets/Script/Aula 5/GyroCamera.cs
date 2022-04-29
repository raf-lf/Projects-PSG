using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    Gyroscope gyro;
    Quaternion startCamera;

    private void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        startCamera = Camera.main.transform.rotation;
    }

    public void UseGyro()
    {
        Vector3 camAngle = gyro.attitude.eulerAngles;
    //    Camera.main.transform.rotation = Quaternion startCamera + gyro.attitude;

    }

    void Update()
    {
        UseGyro();
    }

}
