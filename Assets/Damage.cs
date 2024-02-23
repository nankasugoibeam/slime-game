using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        GrapplingHook controller = other.GetComponent<GrapplingHook>();

        if (controller != null)
        {
            controller.changeHealth(-1);
        }
    }
}
