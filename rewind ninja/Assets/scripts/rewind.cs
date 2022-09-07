using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool isRewinding = false;
    List<PointInTime> pointsInTime;
    [SerializeField] private Transform kunaiCheck;
    [SerializeField] private LayerMask kunai;


    private bool isKunaied(){
        return Physics2D.OverlapCircle(kunaiCheck.position, 10f, kunai);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pointsInTime = new List<PointInTime>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isKunaied()){
            StartRewind();

        }
        if(Input.GetKeyUp(KeyCode.R)){
            StopRewind();
        }
    }

    void FixedUpdate(){
        if(isRewinding){
            Rewind();
        }
        else{
            Record();
        }
    }

    void Rewind(){
        if(pointsInTime.Count > 0){

            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else{
            StopRewind();
        }
    }

    void Record(){
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    void StartRewind(){
        isRewinding = true;
        rb.isKinematic = true;
    }

    void StopRewind(){
        isRewinding = false;
        rb.isKinematic = false;

    }
}
