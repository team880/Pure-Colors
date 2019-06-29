
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float slowedMovementSpeed;
    [SerializeField] private float drag;
    [Header("Dashing")]
    private bool dashing = false;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;

    
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementVector;

    private void Start()
    {
       GetComponents();
    }

    private void Update()
    {
        //print(_input.GetAimDirection(transform.position, _input.GetCursorPosition()));
    }

    private void FixedUpdate()
    {
        MovePlayer(_input.inputVector, Input.GetButton(_input.slowDownButton));
        Dash(_input.inputVector);
    }
    private void GetComponents()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void MovePlayer(Vector2 inputVector, bool goingSlow)
    {
        if(dashing) return;

        if(_input.inputVector.magnitude != 0)
        {
            _movementVector = inputVector;
            if(goingSlow)
            {
                _movementVector = inputVector * slowedMovementSpeed;
            }
            else
            {
                _movementVector = inputVector * movementSpeed;
            }
            _movementVector = Vector2.ClampMagnitude(_movementVector, movementSpeed);
        }
        else
        {
            _movementVector *= drag;
        }
        _rigidbody.velocity = _movementVector;
    }

    private void Dash(Vector2 direction)
    {
        if(!Input.GetButtonDown(_input.dashButton) || dashing) return;
        StartCoroutine("DashCoroutine", direction);
        print("dash");
    }
    private IEnumerator DashCoroutine(Vector2 direction)
    {
        direction = Vector3.Normalize(direction);
        dashing = true;
        float t = 0;
        Vector2 dVector = direction * dashSpeed;
        while(t<dashDuration)
        {
            _movementVector = direction * dashSpeed;
            t+=Time.deltaTime;
            _rigidbody.velocity = dVector;
            yield return null;
        }
        dashing = false;
    }
}
