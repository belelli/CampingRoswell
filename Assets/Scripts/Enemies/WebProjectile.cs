using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebProjectile : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField]
    float _destroyTime;
    [SerializeField]
    float _speed;
    public PlayerMovement player;

    public int damageAmmo = 5; //Carlos: agregu� esta variable para ser usada como da�o cuando el projectil toca al player
    // Start is called before the first frame update

    void Start()
    {
        GetComponent<Rigidbody>().velocity=transform.forward *_speed;    
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void OnTriggerEnter(Collider collision)    
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerAtackWasp hpPlayer = collision.gameObject.GetComponent<PlayerAtackWasp>(); //Carlos: creo variable para acceder a los componentes del jugador
            
            if (hpPlayer != null) //Carlos: se asegura que el componente est� vivito y coleando
            {
                hpPlayer.TakeDamage(damageAmmo); //Carlos: accedo al metodo para hacer da�o
            }

            Destroy(gameObject); // Carlos: mov� el destroy al final
        }
    }
}
