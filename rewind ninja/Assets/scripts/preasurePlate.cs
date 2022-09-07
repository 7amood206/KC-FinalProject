using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preasurePlate : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject emptyDoor;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject box;
    private GameObject newDoor;
    private bool isActivated = false;

    private void Awake() {
        newDoor = Instantiate(door, emptyDoor.transform.position, emptyDoor.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == Player || other.gameObject == box){
            isActivated = !isActivated;
            openDoor();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject == Player || other.gameObject == box){
            isActivated = !isActivated;
            openDoor();
        }
    }

    void openDoor(){
        if (isActivated == true){
            GameObject.Destroy(newDoor);
        }
        else if(isActivated == false){
            newDoor = Instantiate(door, emptyDoor.transform.position, emptyDoor.transform.rotation);
        }
    }

}
