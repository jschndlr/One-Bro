using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] float attackDistance = 2f;
    [SerializeField] float targetCheckInterval = 1f;
    private Transform playerBase;
    private Transform player;
    private NavMeshAgent _agent;
    private float originalSpeed;
    private bool isAttacking;
    private MoveTo _moveTo;
    private Color targetIndicatorColor = Color.green;

    void Awake()
    {
        _moveTo = GetComponent<MoveTo>();
        _agent = GetComponent<NavMeshAgent>();
        SetTargets();
        originalSpeed = _agent.speed;
        StartCoroutine(SetClosestTarget(targetCheckInterval));
    }

    private void SetTargets()
    {
        playerBase = GameObject.FindGameObjectWithTag("Attackable").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        CheckAttackRange();
        Debug.DrawLine(transform.position, _moveTo.goal.position, targetIndicatorColor);
    }

    private void CheckAttackRange()
    {
        var distanceToActiveTarget = Vector3.Distance(transform.position, _moveTo.goal.position);
        if (distanceToActiveTarget < attackDistance)
        {
            Attack();
        }
        else
        {
            Persue();
        }
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            targetIndicatorColor = Color.red;
            _agent.speed = 0f;
        }
        isAttacking = true;
    }

    private void Persue()
    {
        if (isAttacking)
        {
            targetIndicatorColor = Color.green;
            _agent.speed = originalSpeed;

        }
        isAttacking = false;
    }

    private IEnumerator SetClosestTarget(float checkInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);
            Debug.Log(this.name + "Updating Targeting");
            var distanceToBase = Vector3.Distance(playerBase.position, transform.position);
            var distanceToPlayer = Vector3.Distance(player.position, transform.position);
            if (distanceToBase > distanceToPlayer)
            {
                _moveTo.goal = player;
            }
            else
            {
                _moveTo.goal = playerBase;
            }
            
        }
    }
}
