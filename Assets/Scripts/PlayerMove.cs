using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] bool hasGravity = true;

    CharacterController playerCharacter;
    Animator animator;

    void Awake()
    {
        playerCharacter = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Move(Vector3 move)
    {
        move = GravityAdder(move);
        animator.SetFloat("VelX", move.x);
        animator.SetFloat("VelZ", move.z);
        playerCharacter.Move(move * movementSpeed * Time.deltaTime);
    }

    private Vector3 GravityAdder(Vector3 move)
    {
        if (!hasGravity) return move;
        else return move + new Vector3(0f, -9.8f, 0f);
    }
}