using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 _direction;
    [SerializeField]
    float _speed;
    Rigidbody _rigidbody;
    CapsuleCollider _capsuleCollider;
    ForceMode _forceMode;
    //variables para salto//
    //float _jumpForce;
    //bool _wantsToJump;
    public float _rotateSpd = 1;

    //quests
    public Quest quest;
 
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float VerticalAxis = Input.GetAxis("Vertical");
        float HorizontalAxis = Input.GetAxis("Horizontal");
        Vector3 forwardDirection = transform.forward * VerticalAxis;
        Vector3 rightDirection = transform.right * HorizontalAxis;
        _direction = forwardDirection + rightDirection;
        _direction.Normalize();
    }

    private void FixedUpdate()
    {
        //_rigidbody.MovePosition(transform.position + (_speed * _direction * Time.fixedDeltaTime));
        _rigidbody.velocity = _direction * _speed;

        RotatePlayer();
    }

    void RotatePlayer() 
    {
        var rotation = Input.GetAxis("Mouse X") * _rotateSpd * Time.deltaTime * 500;
        transform.Rotate(0f, rotation, 0f);
    }

    //item collection
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Collectible")
        {
            print("entro al collision enter");
            quest.goal.ItemCollected();
            Destroy(collision.gameObject);
            if (quest.goal.isReached())
            {
                quest.Complete();
            }



            
        }
    }




}
