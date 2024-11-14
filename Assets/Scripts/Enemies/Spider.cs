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
    //
    SpiderSFX spiderSfx;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spiderSfx = GetComponent<SpiderSFX>();
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
        /* if (Input.GetKey(KeyCode.E)) { takeDamage(1); } Carlos: comento por que era de prueba */
    }




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
        audioSource = GetComponent<AudioSource>();
        if (currentState != EnemyState.Death && PlayerAtackWasp.currentHealth >= 1) //Carlos: agrego como condición que la vida del player sea mayor a 1 para atacarlo
        {
            if (Time.time >= lastAtk + atkCdw)
            {
                lastAtk = Time.time;
                animator.Play("Attack1");

                if (spiderSfx != null && spiderSfx.soundClips.Count > 0)
                {
                    audioSource.clip = spiderSfx.soundClips[0];  // Facu: Asigno el clip de audio del ataque
                    audioSource.Play(); // Facu: Reproduce el sonido
                }
                else
                {
                    
                }


                // Facu : Instancio la bala 
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.23f)
                {
                    var bullet = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation);
                }

                currentState = EnemyState.Attack;

            }

            currentState = EnemyState.Attack;
        }
        else { currentState = EnemyState.Idle; } //Carlos: agrego que si el player tiene 0 hp, el state sea idle

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
        audioSource.clip = spiderSfx.soundClips[2];
        audioSource.Play();
        //StartCoroutine(GrowAndShrink());

        if (hp <= 0)
        {
            animator.Play("Death");
            audioSource.clip = spiderSfx.soundClips[1];  // Facu: Asigno el clip de audio del ataque
            audioSource.Play();
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

