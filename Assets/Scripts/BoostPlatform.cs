using UnityEngine;

public class BoostPlatform : MonoBehaviour
{
    public float boostAcceleration = 25f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.relativeVelocity.y <= 0.1f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float forceAmount = rb.mass * boostAcceleration;
                rb.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);

                Object.FindFirstObjectByType<PlatformSpawner>().SpawnPlatform();
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