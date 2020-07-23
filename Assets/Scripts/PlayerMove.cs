using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    CharacterController playerCharacter;
    Animator animator;

    void Awake()
    {
        playerCharacter = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Move(Vector3 move)
    {
        animator.SetFloat("VelX", move.x);
        animator.SetFloat("VelZ", move.z);
        playerCharacter.Move(move * movementSpeed * Time.deltaTime);
    }
}