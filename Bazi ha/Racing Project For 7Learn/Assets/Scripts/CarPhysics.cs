using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WheelMotor { Rear, Front, _4x4 }

public class CarPhysics : MonoBehaviour
{
    [Header("Parts")]
    [SerializeField] private WheelCollider[] WC;
    [SerializeField] private Transform[] WM;
    [SerializeField] private Transform COM;
    [SerializeField] private Rigidbody rb;

    [Header("Car")]
    [SerializeField] private WheelMotor m_WheelMotor = WheelMotor.Rear;
    [SerializeField] private float torque = 200;
    [SerializeField] private float maxSteerAngle = 45;
    [SerializeField] private float handbrakePower;
    [SerializeField] private float speedKM;
    [SerializeField] private float engineRPM;
    [SerializeField] private float finalDriveRatio = 3.154f;
    [SerializeField] private float wheelDiameter;
    [SerializeField] private float[] gearRatio;
    [SerializeField] private int gear = 1;

    [Header("Inputs")]
    [SerializeField] private float motorInput;
    [SerializeField] private float steerInput;
    [SerializeField] private float handbrakeInput;

    private void Start()
    {
        rb.centerOfMass = COM.localPosition;
    }

    private void Update()
    {
        GetInput();
        engineRPM = EngineRPM(rb.velocity.magnitude, finalDriveRatio, wheelDiameter, gearRatio[gear]);
        speedKM = rb.velocity.magnitude * 3.6f;
        Gears();

        for (int i = 0; i < WM.Length; i++)
        {
            SetWMWorldPos(i);
        }
    }

    private void FixedUpdate()
    {
        Motor();
        Steer();
        Handbrake();
    }

    private void GetInput()
    {
        motorInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
        handbrakeInput = Input.GetAxis("Jump");
    }

    private void Motor()
    {
        switch (m_WheelMotor)
        {
            case WheelMotor.Rear:
                WC[2].motorTorque = WC[3].motorTorque = motorInput * torque;
                break;
            case WheelMotor.Front:
                WC[0].motorTorque = WC[1].motorTorque = motorInput * torque; ;
                break;
            case WheelMotor._4x4:
                WC[0].motorTorque = WC[1].motorTorque = WC[2].motorTorque = WC[3].motorTorque = motorInput * torque;
                break;
        }
    }

    private void Steer()
    {
        WC[0].steerAngle = WC[1].steerAngle = steerInput * maxSteerAngle;
    }

    private void Handbrake()
    {
        WC[2].brakeTorque = WC[3].brakeTorque = handbrakeInput * handbrakePower;
    }

    private float EngineRPM(float speed, float finalDriveRatio, float wheelDiameter, float gearRatio)
    {
        // Calculate RPM using the formula
        //float rpm = (speed * finalDriveRatio * 336f * gearRatio) / wheelDiameter;

        //return rpm;
        return Mathf.Clamp((speedKM * 16.66666667f) * finalDriveRatio * gearRatio, 1f, 9000);
    }

    private void Gears()
    {
        if (engineRPM >= 7000 && gear < gearRatio.Length - 1)
            gear++;

        if (engineRPM < 3000 && gear > 1)
            gear--;
    }

    private void SetWMWorldPos(int wheelIndex)
    {
        Vector3 pos = Vector3.zero;
        Quaternion rot = Quaternion.identity;
        WC[wheelIndex].GetWorldPose(out pos, out rot);
        WM[wheelIndex].position = pos;
        WM[wheelIndex].rotation = rot;
    }

    public float GetRPM()
    {
        return engineRPM;
    }

    public float GetSpeed()
    {
        return speedKM;
    }
}
