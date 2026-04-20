using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float totalDistance = 0f;
    private Vector3 lastPosition;
    
    void Start()
    {
        lastPosition = transform.position;
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        
        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
        transform.Translate(movement.normalized * moveSpeed * Time.deltaTime, Space.World);
        
        CalculateDistance();
    }
    
    void CalculateDistance()
    {
        float distanceThisFrame = Vector3.Distance(transform.position, lastPosition);
        totalDistance += distanceThisFrame;
        lastPosition = transform.position;
    }
    
    public float GetTotalDistance()
    {
        return totalDistance;
    }
}
