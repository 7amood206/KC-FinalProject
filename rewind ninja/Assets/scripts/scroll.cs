using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scroll : MonoBehaviour
{

     public GameObject canva;
    // public GameObject Fade;
    // public Animator animator;

    void OnTriggerEnter2D(Collider2D other) {
        canva.GetComponent<fade>().loadNextlevel();
        // StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


    // IEnumerator LoadLevel(int levelIndex) {
    //     animator.SetTrigger("start");

    //     yield return new WaitForSeconds(1);

    //     SceneManager.LoadScene(levelIndex);
    // }

}
