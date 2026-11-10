using UnityEngine;
using UnityEngine.InputSystem;

public class jumper : MonoBehaviour
{
    bool jump;
    [SerializeField] float ThrustForce;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddRelativeForce(Vector3.up * ThrustForce * 12000 * Time.fixedDeltaTime);
        jump = false;
    }

    public void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }
}
