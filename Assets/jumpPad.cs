using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    private float jumpforce=400f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*jumpforce,ForceMode2D.Impulse);
            transform.position =Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,
             transform.position.y+3), 0.2f);
        }
    }
    private void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag=="Player"){
            transform.position=Vector2.MoveTowards(transform.position,new Vector2(transform.position.x,
             transform.position.y-3), 0.2f);
        }
    }
}