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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            
        }
    }
}
