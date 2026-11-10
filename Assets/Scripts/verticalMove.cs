using UnityEngine;

public class verticalMove : MonoBehaviour
{
    [SerializeField] private float amplitude = 2f;
    [SerializeField] private float speed = 2f;

    private Vector3 startPosition;
    private float timeOffset = 0f;

    private void Start()
    {
        // Guarda la posición inicial como punto de referencia central
        startPosition = transform.position;
    }
    private void OnEnable()
        {
            // En el momento en que el trigger activa este script,
            // guardamos el segundo exacto de la partida como punto cero.
            timeOffset = Time.time;
        }
    private void Update()
    {
        // Mathf.Sin oscila de forma suave entre -1 y 1
        float elapsedTime = Time.time - timeOffset;
        float newY = startPosition.y + Mathf.Sin(elapsedTime * speed) * amplitude;

        // Mantiene fijos los ejes X y Z originales, modificando solo la altura Y
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
