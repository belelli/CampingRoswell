using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int hp;
    public int maxHP;
    public int dmg;
    public int speed;
    public int range;

    public virtual void chase() { 
    
    }

    public virtual void attack() { }


    public virtual void takeDamage(int damage)
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            hp = hp - damage;
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
