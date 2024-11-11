using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public int hp;
    public int maxHP;
    public int dmg;
    public int speed = 2;
    public int range;
    public float detectionRange = 5f;
    public Transform playerPosition;
    private NavMeshAgent agent;
    public GameObject deathEnemyPart;
    public GameObject itemToDrop;

    public float growthDuration = 0.005f;
    public float growthFactor = 0.005f;

    private Vector3 originalScale;

    public int damage = 10;
    public float attackRange = 5f;
    public float attackCooldown = 2f;

    private float lastAttackTime;
    private Rigidbody _rb;
    private bool hasDroppedItem = false; // Variable para controlar el drop del ítem

    public enum EnemyState
    {
        Idle,
        Chase,
        Attack,
        Damage,
        Death
    }

    public EnemyState currentState = EnemyState.Idle;
    public float chaseSpeed = 5f;
    public int health = 100;

    public Animator animator;
    private Transform player;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Chase:
                chase();
                break;
            case EnemyState.Attack:
                attack();
                break;
            case EnemyState.Damage:
               
                break;
            case EnemyState.Death:
               
                break;
        }
    }

    //public IEnumerator GrowAndShrink()
    //{
    //    Vector3 grownScale = originalScale * growthFactor;

    //    // Grow
    //    float elapsedTime = 0f;
    //    while (elapsedTime < growthDuration)
    //    {
    //        transform.localScale = Vector3.Lerp(originalScale, grownScale, elapsedTime / growthDuration);
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    // Shrink
    //    elapsedTime = 0f;
    //    while (elapsedTime < growthDuration)
    //    {
    //        transform.localScale = Vector3.Lerp(grownScale, originalScale, elapsedTime / growthDuration);
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    transform.localScale = originalScale;
    //}

    public virtual void Idle() //estaba en solo void, lo pasé a virtual para poder overridear en la araña
    {
        animator.SetBool("IsIdle", true);

        if (Vector3.Distance(transform.position, player.position) < 10f)
        {
            currentState = EnemyState.Chase;
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsChasing", true);
        }
    }

    public virtual void chase()
    {
        animator.SetBool("IsChasing", true);

        float distance = Vector3.Distance(playerPosition.position, transform.position);

        if (distance <= detectionRange)
        {


            Vector3 direction = (playerPosition.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            agent.SetDestination(playerPosition.position);
            transform.LookAt(playerPosition);



            if (distance <= attackRange)
            {
                currentState = EnemyState.Attack;
                animator.SetBool("IsChasing", false);
                animator.SetBool("IsAttacking", true);
            }
        }
        else
        {
            currentState = EnemyState.Idle;
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsIdle", true);
            
            
        }
    }

    public virtual void attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            animator.SetBool("IsAttacking", false);            
            currentState = EnemyState.Chase; // Regresar a Chase después de atacar
        }
    }

    public virtual void takeDamage(int damage)
    {
        hp -= damage;
        animator.SetBool("IsDamaging", true);
        //StartCoroutine(GrowAndShrink());

        if (hp <= 0)
        {
            Destroy(_rb);
            currentState = EnemyState.Death;
            animator.SetTrigger("Death"); // Activar la animación de muertes
            Instantiate(deathEnemyPart, transform.position, Quaternion.identity);
            Destroy(gameObject, 2f);
            DropItem();
        }
        else
        {

            currentState = EnemyState.Damage; // Cambiar a estado de daño
            Invoke("ReturnToChase", 0.5f); // Esperar para volver a Chase
        }
    }

    public void DropItem()
    {
        if (!hasDroppedItem) 
        {
            GameObject itemDropped = Instantiate(itemToDrop, transform.position, Quaternion.identity);
            hasDroppedItem = true; // Marcar que el ítem ha sido dropeado

        }

            
    }

    public virtual void ReturnToChase()
    {
        animator.SetBool("IsDamaging", false);

        if (currentState != EnemyState.Death)
        {

            currentState = EnemyState.Chase;

        }
    }
}
