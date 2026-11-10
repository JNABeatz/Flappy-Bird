using UnityEngine;

public class horizontalMove : MonoBehaviour
{
    [SerializeField] private float amplitude = 2f;
    [SerializeField] private float speed = 2f;

    private Vector3 startPosition;

    private void Start()
    {
        // Guarda la posición inicial como punto de referencia central
        startPosition = transform.position;
    }

    private void Update()
    {
        // Mathf.Sin oscila de forma suave entre -1 y 1
        float newX = startPosition.x + Mathf.Sin(Time.time * speed) * amplitude;

        // Mantiene fijos los ejes X y Z originales, modificando solo la altura Y
        transform.position = new Vector3(newX,startPosition.y, startPosition.z);
    }
}
