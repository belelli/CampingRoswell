using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{
    //public Transform player; // Referencia al transform del jugador //Lo comento por que no es necesario crear esta línea, ya tenemos de herencia la linea playerPosition y a ella nos debemos referir en el código
    //public float attackRange = 5f; // Rango de ataque// Lo comento por que no veo donde lo usamos, despues lo chequeamos

    
    [SerializeField] AnimationCurve myCurve;
    


    /* void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {           
            AtackWasp(); 
        }
    }*/
    

    public void Update()
    {

        DetectingPlayer();


        /*if (Vector3.Distance(transform.position, playerPosition.position) <= range)
        {
            AttackPlayer();
        }*/
        

        //levitateAnim();



    }

   /* public void AttackPlayer()
    {
        PlayerHealth playerHealth = playerPosition.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(dmg);
            Debug.Log("Te comiste " + dmg);
        }
    }*/

    public void levitateAnim()
    {        
       
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);

    }

}
