using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxJumpForce = 20f;
    public float chargeRate = 12f;
    private float currentJumpForce = 0f;
    private bool isCharging = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCharging = true;
            currentJumpForce = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && isCharging)
        {
            currentJumpForce += chargeRate * Time.deltaTime;
            currentJumpForce = Mathf.Clamp(currentJumpForce, 0, maxJumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            float forceMagnitude = rb.mass * currentJumpForce;
            rb.AddForce(new Vector2(0, forceMagnitude), ForceMode2D.Impulse);
            isCharging = false;
        }
    }
}
