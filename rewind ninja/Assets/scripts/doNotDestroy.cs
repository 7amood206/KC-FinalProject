using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotDestroy : MonoBehaviour
{
    void Awake(){
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("gameMusic");

        if (musicObj.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
