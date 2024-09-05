using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;          // Texto para mostrar el puntaje
    public Text livesText;          // Texto para mostrar el número de vidas restantes
    public Text timerText;          // Texto para mostrar el temporizador
    public Button restartButton;    // Botón para reiniciar el juego

    private int score = 0;          // Puntaje del jugador
    private int lives = 3;          // Vidas del jugador
    private float elapsedTime = 0f; // Tiempo transcurrido en segundos
    private bool gameIsOver = false;

    void Start()
    {
        // Inicializa el puntaje y las vidas
        UpdateScoreText();
        UpdateLivesText();
        UpdateTimerText();

        // Asegúrate de que el botón de reinicio esté desactivado al inicio
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (!gameIsOver)
        {
            // Actualiza el temporizador
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
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
            Destroy(collision.gameObject);

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

    void UpdateTimerText()
    {
        // Actualiza el texto del temporizador
        timerText.text = "Time: " + Mathf.FloorToInt(elapsedTime).ToString() + "s";
    }

    void GameOver()
    {
        // Pausa el juego y muestra el botón de reinicio
        Time.timeScale = 0;
        gameIsOver = true;
        restartButton.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        // Regresa al menú principal
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); // Asegúrate de que este nombre coincida con tu escena de menú
    }
}



