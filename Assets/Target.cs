using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] Transform targetedObject;
    [SerializeField] float groundOffset;
    public bool showTarget = true;

    private void Awake()
    {
        Instantiate(target);
    }
    void Update()
    {
        
    }
}
