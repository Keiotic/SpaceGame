using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float interpolationSpeed = 10;
    public bool simulateRotation = true;

    /* Behaviour is executed at the same time as physics simulation in order to minimize the jitter-fuckery of the camera
     */
    void FixedUpdate()
    {
        if (target)
        {
            Vector2 lerpVector = Vector2.Lerp(transform.position, target.transform.position, Time.deltaTime * interpolationSpeed);
            Vector3 targetVector = new Vector3(lerpVector.x, lerpVector.y, transform.position.z);
            transform.position = targetVector;

            Quaternion targetRotation = target.transform.rotation;
            Quaternion lerp = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * interpolationSpeed);
            transform.rotation = lerp;
        }
    }
}
