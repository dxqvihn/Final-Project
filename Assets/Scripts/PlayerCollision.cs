using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; // goi phuong thuc them energy

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Player player = GetComponent<Player>();
            player.TakeDamage(10f);
        }
        else if (collision.CompareTag("Usb"))
        {
            Debug.Log("Winnnn!!!!");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Energy")) // neu va cham voi energy
        {
            gameManager.AddEnergy(); // tang energy
            Destroy(collision.gameObject); // xoa energy
        }
    }
}
