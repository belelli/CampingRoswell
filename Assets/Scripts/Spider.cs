using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField] private float _timer;
    [SerializeField] private float _bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float bulletSpeed;
    

    //pa girar
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       ShootAtPlayer();
        rotateTowardsPlayer();
    }

    void ShootAtPlayer()
    {
        
        _bulletTime -= Time.deltaTime;

        print("update! SHOOT");
        if (_bulletTime > 0) return;
        
        _bulletTime = _timer;

        print("Spawneo?");


       var bullet = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation);
       bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
    }

    void rotateTowardsPlayer()
    {
        Vector3 dir = playerPosition.position - transform.position;
        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = rot;
    }

    
}
