using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnCtrl : MonoBehaviour
{
    private static ZombieSpawnCtrl instance = null;
    Queue<GameObject> objectPool = new Queue<GameObject>();

    public GameObject zombie1;
    public GameObject zombie2;
    public GameObject zombie3;

    public GameObject player;

    public Transform[] spawnPoint = new Transform[3];

    public GameObject objectPoolList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public static ZombieSpawnCtrl Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            InitializeNewZombie(zombie1);
            InitializeNewZombie(zombie2);
            InitializeNewZombie(zombie3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objectPool.Count != 0)
        {
            ActiveMob();
        }
    }

    public void InitializeNewZombie(GameObject mob)
    {
        GameObject tmpMob = Instantiate(mob);
        tmpMob.transform.parent = objectPoolList.transform;
        tmpMob.transform.position = spawnPoint[Random.Range(0, 3)].position;
        ZombieCtrl tempSet = tmpMob.GetComponent<ZombieCtrl>();
        tempSet.target = player;
        tempSet.hp = tempSet.saveHP;
        tmpMob.SetActive(false);
        objectPool.Enqueue(tmpMob);
    }
    public void ActiveMob()
    {
        objectPool.Dequeue().SetActive(true);
    }
    public void InactiveMob(GameObject mob)
    {
        mob.transform.position = spawnPoint[Random.Range(0, 3)].position;
        ZombieCtrl tempSet = mob.GetComponent<ZombieCtrl>();
        tempSet.target = player;
        tempSet.hp = tempSet.saveHP;
        mob.SetActive(false);
        objectPool.Enqueue(mob);
    }
}
