using UnityEngine;

public class triggerMove : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private verticalMove objeto;

    private bool triggered = false;

    private void Start()
    {
        // Asegura que el script de movimiento arranque apagado
        if (objeto != null)
        {
            objeto.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag(playerTag))
        {
            triggered = true;

            // Habilita el script original sin tocar su código
            if (objeto != null)
            {
                objeto.enabled = true;
            }
        }
    }
}