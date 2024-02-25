using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corsswind : MonoBehaviour
{
    // Start is called before the first frame update
    public float crossSpeed = 0.1f;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        GrapplingHook controller = other.GetComponent<GrapplingHook>();
        var body = controller.GetComponent<Rigidbody2D>();
        if (controller != null)
        {
            controller.transform.position += new Vector3(crossSpeed,0,0);
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        GrapplingHook controller = other.GetComponent<GrapplingHook>();
        var body = controller.GetComponent<Rigidbody2D>();
        if (controller != null)
        {
        }
       
    }
}

