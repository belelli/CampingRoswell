using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;


public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform ammoPrefab;
    public Transform spawnAmmo;
    public float speed;

    private Transform currentProjectile;

    public float shootCd = 2f; //Carlos: agregando el cooldown de ataque
    private float lastShot;

    
    Animator sAnimator;
    public PlayerAtackWasp _death;

   
    // Start is called before the first frame update
    void Start()
    {
        lastShot = -shootCd; //Carlos: setear el tiempo
        sAnimator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= lastShot + shootCd)
        { sAnimator.SetBool("Shooting", true); }
    }

    

    void fireAmmo()
    {
        Instantiate(projectile, spawnAmmo.transform.position, spawnAmmo.transform.rotation);

        lastShot = Time.time;

        sAnimator.SetBool("Shooting", false);

    }

    public void stuntOff() 
    { 
        sAnimator.SetBool("Stunt", false);
        Debug.Log("FALSO");
    }

    public void deathOn() 
    {
        _death.Die();
    }
}
