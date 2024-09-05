
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button playButton; // Botón de Play

    void Start()
    {
        // Asocia el método StartGame al evento onClick del botón
        playButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // Carga la escena del juego (puedes cambiar el nombre de la escena según lo necesites)
        SceneManager.LoadScene("GameScene"); // Asegúrate de que este nombre coincida con tu escena del juego
    }
}
