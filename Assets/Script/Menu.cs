using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource audio;
   public void PlayGame()
    {
        Time.timeScale = 0.5f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void UIEnable()
    {
        GameObject.Find("Canvas/Menu/UI").SetActive(true);
    }
    public void ClickButton()
    {
        audio.Play();
    }
}
