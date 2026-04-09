using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs; // vien dan ban ra
    [SerializeField] private Transform firePoint; // diem vien dan bay ra
    [SerializeField] private float speedDanThuong = 20f;
    [SerializeField] private float speedDanVongTron = 10f;
    [SerializeField] private float hpValue = 100f;
    [SerializeField] private GameObject miniEnemy; // chua mini enemy
    [SerializeField] private float skillCooldown = 1f; // thoi gian hoi chieu
    private float nextSkillTime = 0f; // tinh toan khi nao dung skill tiep
    [SerializeField] private GameObject usbPrefabs;


    protected override void Update() // test 
    {
        base.Update();
        if (Time.time >= nextSkillTime)
        {
            SuDungSkill();
        }
    }

    protected override void Die()
    {
        Instantiate(usbPrefabs, transform.position, Quaternion.identity);
        base.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(stayDamage);
            }
        }
    }

    private void BanDanThuong() // ki nang 1
    {
        if (player != null)
        {
            Vector3 directionToPlayer= player.transform.position-firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet=Instantiate(bulletPrefabs, firePoint.position,Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * speedDanThuong);
             
        }
    } 

    private void BanDanVongTron() // ki nang 2
    {
        const int bulletCount = 12; // hang so nguyen co so dan ban ra la 12
        float angleStep = 360f / bulletCount; // tinh goc giua moi vien dan
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep ;
            Vector3 bulletDirection=new Vector3(Mathf.Cos(Mathf.Deg2Rad*angle),Mathf.Sin(Mathf.Deg2Rad*angle),0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bulletDirection* speedDanVongTron);
        }
        
    }

    private void HoiMau(float hpAmount) // ki nang 3
    {
        currentHp = Mathf.Min(currentHp + hpAmount, maxHp); // tang luong mau nhg khong vuot luong mau
        UpdateHpBar();
    }

    private void SinhMiniEnemy() // ki nang 4
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);
    }

    private void DichChuyen() // ki nang 5
    {
        if(player != null)
        {
            transform.position=player.transform.position; // dat vi tri enemy boss vao vi tri player
        }
    }

    private void ChonSkillNgauNhien()
    {
        int randomSkill = Random.Range(0, 5);
        switch (randomSkill)
        {
            case 0:
                BanDanThuong();
                break;
            case 1:
                BanDanVongTron();
                break;
            case 2:
                HoiMau(hpValue);
                break;
            case 3:
                SinhMiniEnemy();
                break;
            case 4:
                DichChuyen();
                break;
        }
    }
    private void SuDungSkill()
    {
        nextSkillTime = Time.time + skillCooldown; // Khi goi phuong thuc se  dat lai lan dung skill tiep theo
        ChonSkillNgauNhien();
    }
}
