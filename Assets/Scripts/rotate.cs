using UnityEngine;

public class rotate: MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 90f, 0f);
    private void Update()
    {
        // Multiplica por Time.deltaTime para que el giro sea constante e independiente de los FPS
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
