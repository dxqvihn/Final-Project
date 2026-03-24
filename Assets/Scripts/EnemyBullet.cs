using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 movementDirection; // huong vien dan bay ra

    void Start()
    {
        Destroy(gameObject, 5f); // vien dang ton tai trg 5 giay
    }

    
    void Update()
    {
        if (movementDirection == Vector3.zero) return; // kiem tra huong dan tranh ban tai cho
        transform.position += movementDirection * Time.deltaTime;
    }

    public void SetMovementDirection(Vector3 direction) 
    {
        movementDirection = direction;
    }
}
