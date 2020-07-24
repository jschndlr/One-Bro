using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float damping = 0.5f;
    Vector3 vector = Vector3.zero;
    Vector3 previousLook;
    public void Look(Vector3 target)
    {
        previousLook = transform.position;
        //disable x rotation
        target.y = transform.position.y;
        Vector3 smoothedTarget = Vector3.SmoothDamp(previousLook, target, ref vector, damping);
        transform.LookAt(smoothedTarget);

    }
}
