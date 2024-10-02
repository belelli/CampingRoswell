using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    Animator _animator;

    //Padre
    //public Transform playerParent;

     /* // PLATAFORMA
    Vector3 groundPos;
    Vector3 lastGroundPos;
    Vector3 currentPos;

    string groundName;
    string lastgroundName;

    bool isJump;

    CharacterController characterController;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other)  // Funcion que se cumple si el jugador permanece dentro de nuestro collider marcado como istrigger
    {
        if(other.tag == "platform") 
        {
            if (!isJump) 
            {
                RaycastHit hit;
                if(Physics.SphereCast(transform.position, characterController.radius, -transform.up,out hit)) 
                {
                    GameObject inGround = hit.collider.gameObject; // Almaceno objeto con el que collisiona el raycast
                    groundName = inGround.name;
                    groundPos = inGround.transform.position; // posicion del objeto en el que estamos

                    if(groundPos != lastGroundPos && groundName == lastgroundName) 
                    {
                        currentPos = Vector3.zero; // Reseteo la posicion que avanzara el personaje
                        currentPos += groundPos - lastGroundPos; // calculo la posicion que debera moverse el personaje
                        characterController.Move(currentPos); // agregamos el movimiento calculado a nuestro personaje
                    
                    }

                    lastgroundName = groundName;
                    lastGroundPos = groundPos;
                
                }
            
            }
            if (Input.GetKey(KeyCode.Space))  // si el personaje salta se cumplira esto 
            {
                if (!characterController.isGrounded) // si el jugador no esta en el suelo
                {
                    currentPos = Vector3.zero;
                    lastGroundPos = Vector3.zero;
                    lastgroundName = null;
                    isJump = true;
                
                }
            
            }
            if (characterController.isGrounded)  // si el jugador esta tocando el sueloS
            {
                isJump = false;
            
            }
        
        }
    }
     */






    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _animator = GetComponentInChildren<Animator>();
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

        //JUMP controls
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

        //ANIMATOR
        _animator.SetFloat("Speed", _direction.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        //Usar este para volver al movimiento original(gravedad rota)
        //_rb.velocity = _direction * _speed;

        if (grounded) {
            _rb.AddForce(_speed * _direction * 10f, ForceMode.Force);
        }
        else
        {
            _rb.AddForce(_speed * _direction * 10f * airMultiplier, ForceMode.Force);
        }




        RotatePlayer();
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
