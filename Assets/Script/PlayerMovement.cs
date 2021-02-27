using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float Roatatespeed;
    private Vector2 InputVector = Vector2.zero;
    private Vector3 moveDirection = Vector3.zero;
    Transform playertransform ;
    // [SerializeField] private Rigidbody rb;
    [SerializeField] private float WallDistance = 5.0f;

   
    private void Awake()
    {
        playertransform = transform;
    }

    public void OnMovement(InputValue value)
    {
        //Debug.Log(value.Get());
        InputVector = value.Get<Vector2>();
    }

    private void Update()
    {
        if (!(InputVector.magnitude > 0)) return;


        moveDirection = playertransform.forward * InputVector.y + playertransform.right * InputVector.x;

        Vector3 MovementDirection = moveDirection * (Roatatespeed * Time.deltaTime);
        playertransform.position += MovementDirection;
        //rb.AddForce(MovementDirection);
     
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        if(transform.position.x < 0.1f)
        {
            pos.x = 0.1f;
        }
        else if(transform.position.x > WallDistance)
        {
            pos.x = WallDistance;
        }
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.singleton.GameEnded) return;


        if(collision.gameObject.tag =="Enemy")
        {
            GameManager.singleton.EndGame(false);
        }
    }
}
