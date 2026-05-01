using UnityEngine;

public class Platform : MonoBehaviour
{
    public float targetAcceleration = 12f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float m = rb.mass;
                float a = targetAcceleration;
                float forceAmount = m * a;

                Vector2 force = Vector2.up * forceAmount;
                rb.AddForce(force, ForceMode2D.Impulse);
                if (SoundManager.Instance != null && SoundManager.Instance.sfxSource != null)
                {
                    SoundManager.Instance.PlaySFX(SoundManager.Instance.jumpSound);
                }

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