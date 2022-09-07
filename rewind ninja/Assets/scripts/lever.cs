using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject emptyDoor;
    [SerializeField] private bool inRange = false;
    private GameObject newDoor;
    public bool isOn = false;
    
    
    void Awake(){
        newDoor = Instantiate(door, emptyDoor.transform.position, emptyDoor.transform.rotation);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == Player){
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
         if(other.gameObject == Player){
            inRange = false;
        }
    }

    void Update(){
        if (inRange == true && Input.GetKeyDown(KeyCode.E)){
            Flip();
            opendoor();
        }
    }

    void opendoor(){
        if(isOn == true){
            GameObject.Destroy(newDoor);
        }
        else if (isOn == false){
            newDoor = Instantiate(door, emptyDoor.transform.position, emptyDoor.transform.rotation);
        }
    }

    void Flip(){
        transform.Rotate(0, 180f, 0);
        isOn = !isOn;

    }
}
