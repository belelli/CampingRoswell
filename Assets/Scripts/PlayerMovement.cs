using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float _verticalAxis;
    float _horizontalAxis;
    Vector3 _direction;
    [SerializeField]
    float _speed;
    Rigidbody _rb;
    CapsuleCollider _capsuleCollider;
    public float _rotateSpd = 1;

    //quests
    public Quest quest;
    //Ground check
    public float playerHeight;
    public bool grounded;
    public float groundDrag;
    public LayerMask whatIsGround;

    //variables para salto//
    [Header("Salto")]
    public float _jumpForce;
    public float _jumpCoolDown;
    public float airMultiplier;
    bool readyToJump = true;

    //Variables para Animaciones
    Animator _animator;
    [SerializeField] private string _xAxisName;
    [SerializeField] private string _zAxisName;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _animator = GetComponentInChildren<Animator>(); 
    }



    // Update is called once per frame
    void Update()
    {
        //MOVEMENT Controls
        _verticalAxis = Input.GetAxis("Vertical");
        _horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 forwardDirection = transform.forward * _verticalAxis;
        Vector3 rightDirection = transform.right * _horizontalAxis;
        _direction = forwardDirection + rightDirection;
        _direction.Normalize();

        //JUMP Controls
        print("ready to jump" + readyToJump);
        print("is grounded" + grounded);
        if (Input.GetKey(KeyCode.Space) && readyToJump && grounded) {
            readyToJump = false;
            Jump();
            //investigar sobre esto
            Invoke(nameof(ResetJump), _jumpCoolDown);
        }

        //GroundCheck
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //Handle drag
        if (grounded)
        {
            _rb.drag = groundDrag;
        }
        else
        {
            _rb.drag = 0;
        }


        //Speed Control
        Vector3 flatSpeed = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        print("la velocidad" + flatSpeed.magnitude);
        if (flatSpeed.magnitude > _speed)
        {
            Vector3 limitedVel = flatSpeed.normalized * _speed;
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }

        //ANIMATOR esto setea la velocidad de la animacion a la velocidad de _direction
        //_animator.SetFloat("Speed", _direction.sqrMagnitude);
        _animator.SetFloat(_xAxisName, _verticalAxis);
        _animator.SetFloat(_zAxisName, _horizontalAxis);


    }

    private void FixedUpdate()
    {
        Movement(_verticalAxis, _horizontalAxis);
        RotatePlayer();
    }

    private void Movement(float xAxis, float zAxis)
    {
        if (xAxis != 0f || zAxis !=0) {
            if (grounded)
            {
                _rb.AddForce(_speed * _direction * 10f, ForceMode.Force);
            }
            else
            {
                _rb.AddForce(_speed * _direction * 10f * airMultiplier, ForceMode.Force);
            }
        }
    }


    void RotatePlayer()
    {
        var rotation = Input.GetAxis("Mouse X") * _rotateSpd * Time.deltaTime * 500;
        transform.Rotate(0f, rotation, 0f);
    }


    //JUMP
    private void Jump()
    {
        print("SALTO");
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }



    //ITEM COLLECTION
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
