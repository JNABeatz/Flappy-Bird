using UnityEngine;

public class roundMove : MonoBehaviour
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
        float newY = startPosition.y + Mathf.Cos(Time.time * speed) * amplitude;

        // Mantiene fijos los ejes X y Z originales, modificando solo la altura Y
        transform.position = new Vector3(newX,newY, startPosition.z);
    }
}
