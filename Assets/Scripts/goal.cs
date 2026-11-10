using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] private float waitSeconds = 2f;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject Score;
    [SerializeField] private TMP_Text victoryText;
    bool levelFinished = false;
    float timer = 0f;
    bool showingCredits = false;

    private void Update()
    {
        if (levelFinished && !showingCredits)
        {
            // Acumula tiempo real transcurrido
            timer += Time.unscaledDeltaTime;

            if (timer >= waitSeconds)
            {
                GoToNextLevel();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que sea el jugador y que no se haya activado ya
        if (!levelFinished && other.CompareTag(playerTag))
        {
            levelFinished = true;
            ShowVictory();
            
        }
    }

    private void ShowVictory()
    {
        // Obtener la puntuación final
        int finalScore = 0;
        if (score.Instance != null)
        {
            finalScore = score.Instance.getpoints();
        }

        // Actualizar el texto en pantalla
        if (victoryText != null)
        {
            victoryText.text = $"¡Conseguido!\nPuntos: {finalScore}";
        }

        // Activar el panel
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }

        if (Score != null)
        {
            Score.SetActive(false);
        }

        // Pausar el juego de fondo
        Time.timeScale = 0f;
    }

    private void GoToNextLevel()
    {
        // Restaurar la escala de tiempo antes de cargar la siguiente escena
        Time.timeScale = 1f;

        string currentSceneName = SceneManager.GetActiveScene().name;
Debug.Log($"[ESCENA ACTUAL DETECTADA]: '{currentSceneName}'");
        if (currentSceneName == "Nivel 1")
        {
            SceneManager.LoadScene("Nivel 2");
        }
        else
        {
            showCredits();
        }
    }
        private void showCredits()
    {
        Time.timeScale = 0f;

        showingCredits = true;
    
        // Actualizar el texto en pantalla
        if (victoryText != null)
        {
            victoryText.text = $"Gracias por jugar\n Creado por: Juan Perabá";
        }

        // Activar el panel
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
    }
}