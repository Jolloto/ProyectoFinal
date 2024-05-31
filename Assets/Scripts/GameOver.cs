using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainMenu()       // Carga la escena mainMenu
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f; 
        
    }

    public void RestartGame()   // Carga la escena del Juego
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
}
