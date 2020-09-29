using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ShootingBoundary
{
    public float left;
    public float right;
    public float up;
    public float down;
}
public class ShootingPlayerCtrl : MonoBehaviour
{
    Transform tr;
    bool fireReady = true;

    public Transform firePos;
    public GameObject bullet;

    public int hp;
    public float speed;
    public float fireLate;
    public ShootingBoundary boundary = new ShootingBoundary();
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        tr.Translate(moveDir.normalized * speed * Time.deltaTime);
        Vector2 pos = tr.position;

        pos.x = Mathf.Clamp(pos.x, boundary.left, boundary.right);
        pos.y = Mathf.Clamp(pos.y, boundary.down, boundary.up);

        tr.position = pos;
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.Space) && fireReady)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        fireReady = false;
        Instantiate(bullet, firePos.position, firePos.rotation);
        yield return new WaitForSeconds(fireLate);
        fireReady = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReduceHP(1);
            ShootingSpawnCtrl.Instance.InactiveMob(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            ReduceHP(1);
            Destroy(collision.gameObject);
        }
    }

    void ReduceHP(int damage)
    {
        hp-= damage;
        if (hp <= 0)
        {
            Time.timeScale = 0f;
        }
    }
}
