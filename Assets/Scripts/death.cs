using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    [SerializeField] string deadTag = "obstaculo";
    [SerializeField] float delaySeconds = 2f;

    bool died =false;
    float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (died)
        {
            // Guarda el tiempo real transcurrido.
            timer += Time.unscaledDeltaTime;

            if (timer >= delaySeconds)
            {
                //Restaura la velocidad.
                Time.timeScale = 1f;
                //Carga la escena de nuevo.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
{}        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!died && collision.gameObject.CompareTag(deadTag))
        {
            TriggerDeath();
        }
    }

    private void TriggerDeath()
    {
        died = true;
        Debug.Log("Impacto detectado. Pausando el juego...");

        // Apagar movimiento y salto.
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script != this)
            {
                script.enabled = false;
            }
        }

        // Congela el tiempo de la escena
        Time.timeScale = 0f;
    }
}
