using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player GameObject.
    public GameObject player;

    // The distance between the camera and the player.
    private Vector3 offset;

    // Mouse dragging variables
    private bool isDragging = false;
    private Vector3 lastMousePosition;
    public float rotationSpeed = 150.0f;
    public float minYAngle = -30f;
    public float maxYAngle = 30f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    
    // Return to initial position variables
    private float initialXRotation;
    private float initialYRotation;
    public float returnSpeed = 5.0f;

    // Start is called before the first frame update.
    void Start()
    {
        // Calculate the initial offset between the camera's position and the player's position.
        offset = transform.position - player.transform.position;
        
        // Initialize rotation values based on current camera rotation
        Vector3 angles = transform.eulerAngles;
        xRotation = angles.x;
        yRotation = angles.y;
        
        // Store initial rotation for return functionality
        initialXRotation = xRotation;
        initialYRotation = yRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle mouse drag for camera rotation
        if (Input.GetMouseButtonDown(0)) // Left mouse button down
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) // Left mouse button up
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            
            // Calculate rotation based on mouse movement
            xRotation -= deltaMouse.y * rotationSpeed * Time.deltaTime;
            yRotation += deltaMouse.x * rotationSpeed * Time.deltaTime;
            
            // Clamp vertical rotation to avoid flipping
            xRotation = Mathf.Clamp(xRotation, minYAngle, maxYAngle);
            
            // Apply rotation
            Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            transform.position = player.transform.position + rotation * offset;
            transform.rotation = rotation;
            
            lastMousePosition = Input.mousePosition;
        }
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        // Return to initial position when not dragging
        if (!isDragging)
        {
            // Smoothly interpolate back to initial rotation
            xRotation = Mathf.Lerp(xRotation, initialXRotation, returnSpeed * Time.deltaTime);
            yRotation = Mathf.Lerp(yRotation, initialYRotation, returnSpeed * Time.deltaTime);
            
            // Apply rotation
            Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            transform.position = player.transform.position + rotation * offset;
            transform.rotation = rotation;
        }
    }
}
