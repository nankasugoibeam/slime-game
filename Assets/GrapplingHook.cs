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
    // Start is called before the first frame update
    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        // joint is the line drawn between the player and the clicked surface
        joint.enabled = false;
        rope.enabled = false;
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
            }

        }

        if (joint.enabled)
        {
        joint.distance = Mathf.Max(joint.distance - Time.deltaTime * pullSpeed, CloseDistance);
        }

        if(Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            rope.enabled = false;
        }

        if(rope.enabled == true){
            rope.SetPosition(1, transform.position);
        }
    }
}
