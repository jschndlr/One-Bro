using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public void Look(Vector3 target)
    {
        transform.LookAt(target);
    }
}
