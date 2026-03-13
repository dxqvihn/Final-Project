using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour // khuôn mẫu
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected Player player;
    [SerializeField] protected float maxHp = 50f;
    protected float currentHp;
    [SerializeField] private Image hpBar;

    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;

    protected virtual void Start() //ngoài sử dụng của class cha có thể thêm riêng
    {
        player = FindAnyObjectByType<Player>();
        currentHp = maxHp;
        UpdateHpBar();
    }
    protected virtual void Update() 
    {
        MoveToPlayer();
    }

    protected void MoveToPlayer() //di chuyển enemy tới player
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
            FlipEnemy();
        }
    }
    protected void FlipEnemy() //để enemy luôn hướng về player
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }

    }
    public virtual void TakeDamage(float damage)
    {
        currentHp -= damage; // lay mau tru luong damage
        currentHp = Mathf.Max(currentHp, 0); // dam bao luong mau khong bi duoi 0
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    protected void UpdateHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }

}
