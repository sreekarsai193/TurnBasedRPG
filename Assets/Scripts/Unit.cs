using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    [SerializeField] Animator unitAnimator;
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }
    private void Update()
    {
        float stoppingDistance = .1f;
        if (Vector3.Distance(targetPosition, transform.position) > stoppingDistance)
        {
            float moveSpeed = 5f;
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
            unitAnimator.SetBool("IsWalking", true);
            float rotateSpeed = 10f;
            transform.forward=Vector3.Lerp(transform.forward,moveDirection,Time.deltaTime*rotateSpeed);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }
    

    }
    public void Move(Vector3 targetPosition)
    {
        this.targetPosition=targetPosition;
    }
}
