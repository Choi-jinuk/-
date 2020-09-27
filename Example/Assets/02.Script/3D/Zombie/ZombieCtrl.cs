using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieCtrl : MonoBehaviour
{
    NavMeshAgent nav;
    Animator anim;
    public GameObject target;

    public int hp;
    public int saveHP;

    private void Awake()
    {
        saveHP = hp;
    }
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = target.transform.position;
        float distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

        if (distance <= nav.stoppingDistance)
        {
            anim.SetBool("isWalk", false);
        }
        else
        {
            anim.SetBool("isWalk", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            hp--;
            if (hp <= 0)
            {
                ZombieSpawnCtrl.Instance.InactiveMob(gameObject);
            }
        }
    }
}
