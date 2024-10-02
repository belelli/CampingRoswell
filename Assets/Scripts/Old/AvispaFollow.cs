using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvispaFollow : MonoBehaviour
{
    public Transform player; 
    public float followRange = 5f; 
    public float moveSpeed = 1f;
    public float turnSpeed;

    /* public float lineLength; un comando para ver una cosita de direccion*/

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (distanceToPlayer < followRange)
        {
            FollowPlayer();
            LookAtPlayer();
            /*OnGizmos(); un comando para ver una cosita de direccion*/
        }
    }

    void FollowPlayer()
    {

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void LookAtPlayer()
    {

        Vector3 dir = player.position - transform.position;
        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = rot;
    }

    /* void OnGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * lineLength);
    } un comando para ver una cosita de direccion*/

}
