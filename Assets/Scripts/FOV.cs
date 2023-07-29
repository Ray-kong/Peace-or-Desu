using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FOV : MonoBehaviour
{
    // FOV radius
    public float viewRadius;
    private int cnt = 0;


    // FOV angle
    [Range(0, 360)]
    public float viewAngle;

    // LayerMask to identify targets
    public LayerMask targetMask;
    
    // LayerMask to identify obstacles
    public LayerMask obstacleMask;

    public GameObject fovVisualObject;
    // List of targets visible from the current position
    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        // Start the Coroutine to find targets with a delay
        StartCoroutine("FindTargetsWithDelay", .2f);
    }
    
    private void Update()
    {
        if (cnt > 1800)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            foreach (Transform visibleTarget in visibleTargets)
            {
                cnt++;
            }
        }
    }

    // Coroutine that finds targets with a delay
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    // Find all visible targets within the FOV
    void FindVisibleTargets()
    {
        // Clear the list of visible targets
        visibleTargets.Clear();

        // Find all targets in view radius
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        // Check every target if it's within the view angle and not blocked by an obstacle
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector2 dirToTarget = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;
            
            // If the target is within the view angle
            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);
                
                // If the target is not blocked by an obstacle
                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    // Add the target to the list of visible targets
                    visibleTargets.Add(target);
                    Debug.Log(target.name + " is visible");
                }
            }
        }
    }

    // Convert an angle into a direction
    public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
      if (!angleIsGlobal)
    {
      angleInDegrees += transform.eulerAngles.z;
    }
    return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }




    // Draw the FOV in the Unity Editor for debug purposes
    void OnDrawGizmos()
    {
        // Draw the view radius as a yellow circle
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
        
        // Draw the view angle
        Vector2 viewAngleA = DirFromAngle(-viewAngle / 2, false);
        Vector2 viewAngleB = DirFromAngle(viewAngle / 2, false);

        Gizmos.DrawLine(transform.position, transform.position + (Vector3)viewAngleA * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)viewAngleB * viewRadius);

        if (fovVisualObject != null)
        {
            fovVisualObject.transform.rotation = Quaternion.Euler(0f, 0f,0f);
        }

        // Draw lines to visible targets
        Gizmos.color = Color.red;
        foreach (Transform visibleTarget in visibleTargets)
        {
            Gizmos.DrawLine(transform.position, visibleTarget.position);
        }
    }

   
}
