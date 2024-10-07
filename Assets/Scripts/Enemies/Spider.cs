using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField] private float _timer;
    [SerializeField] private float _bulletTime;
    public Transform spawnPoint;
    public float bulletSpeed;
    public GameObject enemyBullet;

    [SerializeField] Animator _animator;
    
    

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

        if (Input.GetKey(KeyCode.E)) { _animator.Play("TakeDamage"); }
        if (Input.GetKey(KeyCode.Q)) 
        {           
            _animator.Play("Death",-1,0f);
            

        }

    }

    

    void ShootAtPlayer()
    {       

        _bulletTime -= Time.deltaTime;
        if (_bulletTime <= 0) 
        {
            _animator.Play("Attack1");

            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.23f) 
            {                
                _bulletTime = _timer;
                var bullet = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation);
            }
            

        };   

       
       //bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
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
