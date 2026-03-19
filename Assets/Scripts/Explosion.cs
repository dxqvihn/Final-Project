using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damage = 25f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
