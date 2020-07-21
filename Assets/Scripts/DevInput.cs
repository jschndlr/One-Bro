using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevInput : MonoBehaviour
{

    [SerializeField] PlayerMove _playerMove;
    [SerializeField] PlayerLook _playerLook;

    private Vector3 move;
    private Camera _mainCamera;
    

    void Start()
    {
        if (_playerMove == null)
        {
            Debug.Log("No player move attached");
        }

        if (_playerLook == null)
        {
            Debug.Log("No player look attached");
        }

        _mainCamera = Camera.main;
    }

    void Update()
    {
        MovePlayer();
        PlayerLook();
    }

    private void MovePlayer()
    {
        move.z = Input.GetAxis("Vertical");
        move.x = Input.GetAxis("Horizontal");
        _playerMove.Move(move);
    }

    private void PlayerLook()
    {
        RaycastHit _hit;
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit))
        {
            _playerLook.Look(_hit.point);
            Debug.DrawLine(_playerLook.transform.position, _hit.point, Color.blue);
        }
    }
}
