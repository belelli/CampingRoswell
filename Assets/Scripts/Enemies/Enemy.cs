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
    /*public Vector3 CollCenter; Carl: deprecated variable*/

    public float growthDuration = 0.005f;
    public float growthFactor = 0.005f;

    private Vector3 originalScale;

    public int damage = 10;
    public float attackRange = 5f;
    public float attackCooldown = 2f;

    private float lastAttackTime;

    public virtual void chase() 
    {
        float distance = Vector3.Distance(playerPosition.position, transform.position);

        if (distance <= detectionRange)
        {
            Vector3 direction = (playerPosition.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
            agent.SetDestination(playerPosition.position);

        }
    }
    

    public virtual void attack() 
    {
        if (Vector3.Distance(transform.position, PlayerAtackWasp.instance.transform.position) < attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                attack();
                lastAttackTime = Time.time;
            }
        }


    }


    public virtual void takeDamage(int damage)
    {
        hp -= damage;

        GrowAndShrink();

        if (hp <= 0)
        {
            
            Destroy(gameObject);
            Instantiate(deathEnemyPart, transform.position, Quaternion.identity);//Carl: cambié el collcenter por transform.position, funciona bien en la nueva avispa prefab con todo centrado digamos
            DropItem();

        }
    }

    public void DropItem()
    {
        GameObject itemDropped = Instantiate(itemToDrop, transform.position, Quaternion.identity);//Carl: idem linea 53
    }



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        /*BoxCollider boxCollider = GetComponent<BoxCollider>();Carl: decrecated line*/
        /*CollCenter = boxCollider.transform.TransformPoint(boxCollider.center); Carl: deprecated line*/
        originalScale = transform.localScale;

        
    }

    // Update is called once per frame
    void Update()
    {
        chase(); //Carlos: comenté las líneas viejas de navmesh, pruebo con este otro método que le agregué para perseguir
       // DetectingPlayer();
    }
    

    public IEnumerator GrowAndShrink()
    {
        Vector3 grownScale = originalScale * growthFactor;

        // Grow
        float elapsedTime = 0f;
        while (elapsedTime < growthDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, grownScale, elapsedTime / growthDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Shrink
        elapsedTime = 0f;
        while (elapsedTime < growthDuration)
        {
            transform.localScale = Vector3.Lerp(grownScale, originalScale, elapsedTime / growthDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;
    }


}
