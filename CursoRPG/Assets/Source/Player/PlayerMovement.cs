using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidad;

    private Rigidbody2D _rigidBody2D;
    private Vector2 _direccionMov; 
    public Vector2 DireccionMov => _direccionMov;
    public bool EnMoviento => _direccionMov.magnitude > 0f;
    private Vector2 _input;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Direcci�n x
        if (_input.x > 0.1f)
        {
            _direccionMov.x = 1f;
        }
        else if(_input.x < 0f)
        {
            _direccionMov.x = -1f;
        }
        else
        {
            _direccionMov.x = 0f;
        }
        //Direcci�n de y
        if(_input.y > 0.1f)
        {
            _direccionMov.y = 1f;
        }
        else if(_input.y < 0f)
        {
            _direccionMov.y = -1f;
        }
        else
        {
            _direccionMov.y = 0f;
        }

        
    }
    private void FixedUpdate()
    {
        _rigidBody2D.MovePosition(_rigidBody2D.position + _direccionMov * velocidad * Time.fixedDeltaTime);
    }
}
