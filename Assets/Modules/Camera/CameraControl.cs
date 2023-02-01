using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f; //Approx time for camera movement                 
    public float m_ScreenEdgeBuffer = 4f; //Buffer for the players to be in screen           
    public float m_MinSize = 6.5f; // Minimum zoom for the camera                 
    public Transform[] m_Targets; // Array of transforms, players

    private Camera m_Camera; // Reference to camera                        
    private float m_ZoomSpeed; // Damp variable for zoom speed                      
    private Vector3 m_MoveVelocity; // Damp variable for movevelocity                  
    private Vector3 m_DesiredPosition; // Average of both players position= desired position. CameraRig = desiredposition = follow  

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        CameraMove();
        CameraZoom();
    }
    
    private void CameraMove()
    {
        FindAveragePosition(); // Find average position

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime); // Set that position, and make the convertions smoothly
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3(); // New vector
        int numTargets = 0; // Number of targets that should be averaged

        for (int i = 0; i < m_Targets.Length; i++) // Loop through amount of players
        {
            if (!m_Targets[i].gameObject.activeSelf) // Check if the gameobject(player)is deactivated. Null-check. Dont want to follow "dead" player
                continue; // Back to for loop

            averagePos += m_Targets[i].position; // Add position to the averagepos
            numTargets++; // Increment number of targets
        }

        if (numTargets > 0) // If there are active targets
            averagePos /= numTargets;

        averagePos.y = transform.position.y; // Dont change the y-position(Inherit camera rig y-position). Safety

        m_DesiredPosition = averagePos;
    }


    private void CameraZoom()
    {
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }


    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

        float size = 0f; // Largest size picked

        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position); // World to local space

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / m_Camera.aspect);
        }

        size += m_ScreenEdgeBuffer;

        size = Mathf.Max(size, m_MinSize);

        return size;
    }


    public void SetStartPositionAndSize() // Reseting scene every start of round
    {
        FindAveragePosition();

        transform.position = m_DesiredPosition;

        m_Camera.orthographicSize = FindRequiredSize();
    }
}

