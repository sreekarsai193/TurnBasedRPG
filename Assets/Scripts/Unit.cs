using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    private void Update()
    {
        float stoppingDistance = .1f;
        if (Vector3.Distance(targetPosition, transform.position) < stoppingDistance)
        {
            float moveSpeed = 5f;
            Vector3 MoveDirection = (targetPosition - transform.position).normalized;
            transform.position += MoveDirection * Time.deltaTime * moveSpeed;   
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Move(new Vector3(4, 0, 4));
        }

    }
    private void Move(Vector3 targetPosition)
    {
        this.targetPosition=targetPosition;
    }
}
