using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public Transform Projectile;
    public Transform DrawFrom;
    public Transform DrawTo;
    public Transform spawnAmmo;


    public StringPoint slingshotString;
    public int NrDrawIncrements = 10;

    private Transform currentProjectile;

    private bool draw;
   
    public float shootCd = 2f; //Carlos: agregando el cooldown de ataque
    private float lastShot;

    public float speed = 2;

    public GameObject _player;
    Animator sAnimator;

    // Start is called before the first frame update
    void Start()
    {
        lastShot = -shootCd; //Carlos: setear el tiempo
        sAnimator = _player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //sAnimator.SetBool("Shooting", true);
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= lastShot + shootCd)
        { DrawSlingShot(1); }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        { ReleaseAndShoot(50); }

            
    }

    public void ReleaseAndShoot(float shotForce)
    {
        draw = false;
        if (currentProjectile != null)
        {
            currentProjectile.transform.parent = null;
            Rigidbody projectileRigidBody = currentProjectile.GetComponent<Rigidbody>();
            projectileRigidBody.isKinematic = false;
            projectileRigidBody.AddForce(transform.forward * shotForce, ForceMode.Impulse);
            slingshotString.CenterPoint = DrawFrom;
            lastShot = Time.time; //Carlos: cambia el tiempo del ultimo disparo

            sAnimator.SetBool("Shooting",false);

            currentProjectile = null;
        }
              
        
    }

    public void DrawSlingShot(float speed)
    {
        draw = true;

        sAnimator.SetBool("Shooting", true);

        currentProjectile = Instantiate(Projectile, spawnAmmo.position, Quaternion.identity, transform );
        currentProjectile.forward = transform.forward;
        slingshotString.CenterPoint = currentProjectile.transform;

        float waitTimeBetweenDraws = speed / NrDrawIncrements;
        StartCoroutine(drawSlingShotWithIncrements(waitTimeBetweenDraws));
    }

    private IEnumerator drawSlingShotWithIncrements(float waitTimeBetweenDraws)
    {
        for (int i = 0; i < NrDrawIncrements; i++)
        {
            if (draw)
            {
                currentProjectile.transform.position = Vector3.Lerp(DrawFrom.position, DrawTo.position, (float)i / NrDrawIncrements);
                yield return new WaitForSeconds(waitTimeBetweenDraws);
            }
            else
            {
                i = NrDrawIncrements;
            }
        }
    }
}
