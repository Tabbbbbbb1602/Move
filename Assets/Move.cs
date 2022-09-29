using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    private CharacterController controller;
    public Transform PositionBall;
    public GameObject Ball;

    public Player touchControls;

    Vector3 direction;
    Vector3 StartPos;
    Vector3 EndPos;

    private void Awake()
    {
        touchControls = new Player();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Update()
    {
        
    }

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        StartPos = Ball.transform.position;
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        EndPos = transform.position;
        MovePlayer();
        //ThrowBall();
    }

   /* private void ThrowBall()
    {
        EndPos.y = 0;
        StartPos.y = 0;
        direction = ((EndPos - StartPos) + new Vector3(1 , 0, 1)).normalized;
        Ball.GetComponent<Rigidbody>().AddForce(direction * 10.0f, ForceMode.Impulse);
    }*/

    private void MovePlayer()
    {
        Debug.Log("run");
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * 10.0f);
    }
}
