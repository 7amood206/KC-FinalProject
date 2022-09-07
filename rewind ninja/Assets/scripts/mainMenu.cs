using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void level_1(){
        SceneManager.LoadScene("level_1");
    }
    public void level_2(){
        SceneManager.LoadScene("level_2");
    }
    public void level_3(){
        SceneManager.LoadScene("level_3");
    }
    public void level_4(){
        SceneManager.LoadScene("level_4");
    }
    public void level_5(){
        SceneManager.LoadScene("level_5");
    }
    public void level_6(){
        SceneManager.LoadScene("level_6");
    }

    public void quitgame(){
        Application.Quit();
    }
}
