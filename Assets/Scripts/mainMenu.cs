using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider volumeSlider;
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button ExitButton;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void StartGame()     //Funcion que inicia el juego cargando la escena
    {
        SceneManager.LoadScene(3);
    }

    public void ExitGame()  // Funcion que te hace salir del juego
    {
        Application.Quit();
    }

    public void SetVolume()     // El volumen ajustado en el Slider del Main Menu se queda como lo has ajustado al empezar el juego
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        AudioListener.volume = volumeSlider.value;
    }
}