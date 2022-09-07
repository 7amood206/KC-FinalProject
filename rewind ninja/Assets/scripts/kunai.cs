using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunai : MonoBehaviour
{
    
    private Rigidbody2D rb;
    bool hasHit = false;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(hasHit == false){

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision){
        transform.parent = collision.transform;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        hasHit = true;
    }
}
