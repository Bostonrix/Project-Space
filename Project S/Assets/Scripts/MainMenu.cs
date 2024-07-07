using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() {
        SceneManager.LoadScene("Comic");
    }
    
    public void QuitGame() {
        Application.Quit();
    }

    public void ReturnGame(){
        SceneManager.LoadScene("MainMenu");
    }


}
