using UnityEngine;

public class coleccionable : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f,0f);
    }
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        if (score.Instance != null)
        {
            score.Instance.AddPoints(50);
        }
        Destroy(gameObject);
    }
}
}