using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevInput : MonoBehaviour
{

    [SerializeField] PlayerMove _playerMove;

    private Vector3 move;
    

    // Start is called before the first frame update
    void Start()
    {
        if (_playerMove == null)
        {
            Debug.Log("No player move attached");
        }
    }

    // Update is called once per frame
    void Update()
    {
        move.z = Input.GetAxis("Vertical");
        move.x = Input.GetAxis("Horizontal");
        _playerMove.Move(move);
    }
}
