using UnityEngine;

public class OneTimePlatform : MonoBehaviour
{
    public float targetAcceleration = 12f;
    public float destructionDelay = 0.2f;
    private bool isStepped = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.relativeVelocity.y <= 0.1f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null && !isStepped)
            {
                isStepped = true;

                float forceAmount = rb.mass * targetAcceleration;
                rb.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);

                Object.FindFirstObjectByType<PlatformSpawner>().SpawnPlatform();

                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                if (sr != null) sr.color = Color.red;

                Destroy(gameObject, destructionDelay);
            }
        }
    }

    void Update()
    {
        if (transform.position.y < Camera.main.transform.position.y - 10f)
        {
            Destroy(gameObject);
        }
    }
}