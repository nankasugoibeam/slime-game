using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;
    private Vector3 grapplePoint;
    private DistanceJoint2D joint;
    [SerializeField] private float pullSpeed;
    [SerializeField] private float CloseDistance;
    [SerializeField] private int maxHealth;
    private int currentHealth;
    public float timeInvincible;
    bool isInvincible;
    float invincibleTimer;
    //fore the first frame update
    private Transform attachedPlatform; // Reference to the platform the hook is attached to
    private Vector3 offsetFromPlatform; // Offset of the grapple point from the platform's origin

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        // joint is the line drawn between the player and the clicked surface
        joint.enabled = false;
        rope.enabled = false;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetMouseButtonDown(0))
        {   
            Vector3 mouse = Input.mousePosition;
            Vector3 point = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 direction = mouse - point;
            direction.z = 0f;
            direction = direction.normalized;
            transform.up = direction;

            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.1f, 0), direction, grappleLength, grappleLayer);

            if(hit.collider != null)
            {
                grapplePoint = hit.point;
                grapplePoint.z = 0;
                joint.connectedAnchor = grapplePoint;
                joint.enabled = true;
                joint.distance = grappleLength;
                rope.SetPosition(0, grapplePoint);
                rope.SetPosition(1, transform.position);
                rope.enabled = true;

                // Check if the hit object is a moving platform
                if (hit.collider.gameObject.CompareTag("MovingPlatform")) // Make sure your platform has the tag "MovingPlatform"
                {
                    attachedPlatform = hit.collider.transform;
                    offsetFromPlatform = attachedPlatform.InverseTransformPoint(grapplePoint);
                }
                else
                {
                    attachedPlatform = null;
                }
            }

        }

        if (joint.enabled)
        {
        joint.distance = Mathf.Max(joint.distance - Time.deltaTime * pullSpeed, CloseDistance);
        
        // If attached to a moving platform, update the grapple point
            if (attachedPlatform != null)
            {
                grapplePoint = attachedPlatform.TransformPoint(offsetFromPlatform);
                joint.connectedAnchor = grapplePoint;
                rope.SetPosition(0, grapplePoint);
                joint.distance = joint.distance - pullSpeed/60;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            rope.enabled = false;
            attachedPlatform = null; // Clear the platform reference
        }

        if(rope.enabled == true){
            rope.SetPosition(1, transform.position);
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        if(currentHealth == 0){
            transform.position = new Vector3(-7, 1, 0);
            currentHealth = maxHealth;
        }
    }

        

    public void changeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
