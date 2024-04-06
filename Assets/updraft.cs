using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updraft : MonoBehaviour
{
    public float upspeed = 0.1f;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        GrapplingHook controller = other.GetComponent<GrapplingHook>();
        var body = controller.GetComponent<Rigidbody2D>();
        if (controller != null)
        {
            controller.transform.position += new Vector3(0,upspeed,0);
            body.gravityScale = 0;
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        GrapplingHook controller = other.GetComponent<GrapplingHook>();
        var body = controller.GetComponent<Rigidbody2D>();
        if (controller != null)
        {
            body.gravityScale = 6;
        }
       
    }

}
