using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    
    public Transform spawnPoint;
    public float bulletSpeed;
    public GameObject enemyBullet;
    public float lastAtk;
    public float atkCdw = 4f;




    //pa girar
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;            
            case EnemyState.Attack:
                attack();
                break;
            case EnemyState.Damage:

                break;
            case EnemyState.Death:

                break;
        }
        attack();
        rotateTowardsPlayer();
        if (Input.GetKey(KeyCode.E)) { takeDamage(1); }
    }



    //void ShootAtPlayer()
    //{

    //    _bulletTime -= Time.deltaTime;
    //    if (_bulletTime <= 0)
    //    {
    //        attack();

    //        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.23f)
    //        {
    //            _bulletTime = _timer;
    //            var bullet = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation);
    //        }


    //    };


    //    //bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
    //}

    void rotateTowardsPlayer()
    {
        Vector3 dir = playerPosition.position - transform.position;
        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = rot;
    }

    public override void Idle()
    {
        animator.SetBool("IsIdle", true);

    }

    public override void chase()
    {
        //dejo vacío ya que chase no lo usamos en la spider
    }

    public override void attack()
    {
        if (currentState != EnemyState.Death ) 
        {
            if (Time.time >= lastAtk + atkCdw)
            {
                lastAtk = Time.time;
                animator.Play("Attack1");

                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.23f)
                {
                    var bullet = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation);

                }

            };

            currentState = EnemyState.Attack;
        }
        
    }

    public override void ReturnToChase()
    {
        //idem línea 75
    }

    public override void takeDamage(int damage)
    {
        animator.Play("TakeDamage");
        hp -= damage;
        animator.SetBool("IsDamaging", true);
        //StartCoroutine(GrowAndShrink());

        if (hp <= 0)
        {
            animator.Play("Death");
            currentState = EnemyState.Death;
            Instantiate(deathEnemyPart, transform.position, Quaternion.identity);
            animator.SetTrigger("Death"); // Activar la animación de muertes
            DropItem();
            
            Destroy(gameObject, 4.5f);
            
        }
        else
        {

            currentState = EnemyState.Damage; // Cambiar a estado de daño
            
        }
    }



}
