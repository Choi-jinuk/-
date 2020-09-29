using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyCtrl : MonoBehaviour
{
    public float speed;
    public float hp;
    public int firePercent;

    public Transform firePos;
    public GameObject bullet;

    float countHP;
    bool readyFire = true;
    private void OnEnable()
    {
        countHP = hp;
    }
    void Awake()
    {
        countHP = hp;
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);

        if (readyFire)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        readyFire = false;
        if (Random.Range(0, firePercent+1) == 0)
        {
            Instantiate(bullet, firePos.position, firePos.rotation);
        }
        yield return new WaitForSeconds(0.5f);
        readyFire = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            countHP--;
            if (countHP <= 0)
            {
                Dead();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLine"))
        {
            Dead();
        }
    }
    void Dead()
    {
        ShootingSpawnCtrl.Instance.InactiveMob(gameObject);
    }
}
