using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardwareStuff : MonoBehaviour
{
    public Text accelerationText;
    public Text gyroText;
    public Text gpsText;
    public Rigidbody2D bob;
    public float bobSpeed;
    Gyroscope gyro;

    private void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        Input.location.Start();
        //Invoke(nameof(StartGPS),2);
    }

    private void UseGps()
    {
        gpsText.text = ("GPS = " + Input.location.lastData.altitude + " - " + Input.location.lastData.latitude + " - " + Input.location.lastData.longitude);

    }

    void StartGPS()
    {
        UseGps();
    }

    public void UseGyro()
    {
        gyroText.text = ("Gyroscope = " + gyro.attitude);

    }

    public void UseAcelerometro()
    {
        accelerationText.text = ("Aceleration = " + Input.acceleration);
        bob.velocity = Input.acceleration * bobSpeed;

    }

    void Update()
    {
           UseAcelerometro();
        UseGyro();
    }
}
