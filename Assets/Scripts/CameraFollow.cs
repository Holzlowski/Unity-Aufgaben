using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 8f;
    public float smoothRotationSpeed = 8f;
    public Vector3 offset;

    private void Start()
    {
        //das Player Objekt wird hier gesucht, was ein wenig Zeit einspart
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // LateUpdate erfolgt nach dem Update pro Frame 
    private void LateUpdate()
    {
        //der Abstand zwischen Kamera und Objekt wird hier berechnet 
        Vector3 offsetRotated = target.rotation * offset;
        Vector3 desiredPosition = target.position + offsetRotated;
        //die Kamera folgt dem Objekt mit einer gewissen Verzögerung
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        //die Kamera rotiert zum Objekt
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        //die Rotation der Kamera erfolgt ebenfalls mit einer Verzögerung
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothRotationSpeed * Time.deltaTime);
        transform.rotation = smoothedRotation;

        //transform.LookAt(target);
    }
}
