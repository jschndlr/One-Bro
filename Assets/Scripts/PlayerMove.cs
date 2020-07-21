using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    CharacterController playerCharacter;

    void Awake()
    {
        playerCharacter = GetComponent<CharacterController>();
    }

    public void Move(Vector3 move)
    {
        playerCharacter.Move(move * movementSpeed * Time.deltaTime);
    }
}
