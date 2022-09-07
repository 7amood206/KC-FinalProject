using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pausemenu;
    [SerializeField] private GameObject playerHand;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (paused == true){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        playerHand.GetComponent<kunaiThrower>().enabled = true;

    }
    void Pause(){
        playerHand.GetComponent<kunaiThrower>().enabled = false;
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        playerHand.GetComponent<kunaiThrower>().enabled = true;
    }

    public void quit(){
        SceneManager.LoadScene("menu_1");
        Time.timeScale = 1f;
        playerHand.GetComponent<kunaiThrower>().enabled = true;
    }


}
