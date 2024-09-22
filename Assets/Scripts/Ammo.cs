using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int damage = 5;
    public float destroyTimer = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        { 
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.takeDamage(damage);
            }

            Destroy(gameObject, destroyTimer);
        
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
