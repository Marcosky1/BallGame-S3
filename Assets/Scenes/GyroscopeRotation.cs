using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeRotation : MonoBehaviour
{
    private Quaternion baseRotation = new Quaternion(0, 0, 1    , 0);

    private Gyroscope gyroscope;
    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;

            Debug.Log("Gyroscope enable");
        }
    }

    private void Update()
    {
        transform.localRotation = gyroscope.attitude * baseRotation;
    }
}
