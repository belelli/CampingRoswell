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
    public Vector3 CollCenter;

    public float growthDuration = 0.005f;
    public float growthFactor = 0.005f;

    private Vector3 originalScale;

    public virtual void chase() { 
    
    }

    public virtual void attack() { }


    public virtual void takeDamage(int damage)
    {
        hp -= damage;

        GrowAndShrink();

        if (hp <= 0)
        {   
            Destroy(gameObject);
            Instantiate(deathEnemyPart, CollCenter, Quaternion.identity);
            DropItem();

        }
    }

    public void DropItem()
    {
        GameObject itemDropped = Instantiate(itemToDrop, CollCenter, Quaternion.identity);
    }



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        CollCenter = capsuleCollider.transform.TransformPoint(capsuleCollider.center);
        originalScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        DetectingPlayer();
    }

    public void DetectingPlayer() 
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
