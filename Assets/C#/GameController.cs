using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;          // Texto para mostrar el puntaje
    public Text livesText;          // Texto para mostrar el n�mero de vidas restantes
    public Button restartButton;    // Bot�n para reiniciar el juego

    private int score = 0;          // Puntaje del jugador
    private int lives = 3;          // Vidas del jugador

    void Start()
    {
        // Inicializa el puntaje y las vidas
        UpdateScoreText();
        UpdateLivesText();

        // Aseg�rate de que el bot�n de reinicio est� desactivado al inicio
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica el tag del objeto con el que colision�
        if (collision.gameObject.CompareTag("Points"))
        {
            // Aumenta el puntaje y actualiza el texto
            score += 1;
            UpdateScoreText();
            Destroy(collision.gameObject); // Destruye el objeto de puntos
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Reduce la vida y actualiza el texto
            lives -= 1;
            UpdateLivesText();

            // Verifica si las vidas se acabaron
            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    void UpdateScoreText()
    {
        // Actualiza el texto del puntaje
        scoreText.text = "Score: " + score;
    }

    void UpdateLivesText()
    {
        // Actualiza el texto de las vidas
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        // Pausa el juego y muestra el bot�n de reinicio
        Time.timeScale = 0;
        restartButton.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        // Regresa al men� principal
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); // Aseg�rate de que este nombre coincida con tu escena de men�
    }
}

