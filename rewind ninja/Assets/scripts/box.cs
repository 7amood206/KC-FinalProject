using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Kunai;
    private Rigidbody2D rg;

    void Start(){
        rg = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject == Player){
            Player.transform.parent = transform;
        }
        else if(other.gameObject == Kunai){
            rg.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject == Player){
            Player.transform.parent = null;
        }
    }

}
