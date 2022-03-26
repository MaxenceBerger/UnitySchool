using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void MenuBack()
    {
        SceneManager.LoadScene("MenuScenes");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
