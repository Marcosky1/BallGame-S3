
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button playButton; // Bot�n de Play

    void Start()
    {
        // Asocia el m�todo StartGame al evento onClick del bot�n
        playButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // Carga la escena del juego (puedes cambiar el nombre de la escena seg�n lo necesites)
        SceneManager.LoadScene("GameScene"); // Aseg�rate de que este nombre coincida con tu escena del juego
    }
}
