using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private float VerticalSpeed;
    private float HorizontalSpeed;
    private float Forward;
    private float Side;
    private Vector3 Direction;
    public CharacterController controller;
    public float RunSpeed;
    public float RotaSpeed;
    private Camera MainCam;
    public Animator anim;
    public float Gravity;
    private float fallRate = 0;
    private float smoothSpeed;
    private float forwardSpeed;
    private float sideSpeed;
    enum PlayerState { Idle, Moving, Falling }
    [SerializeField] PlayerState CurrentState;
    void Start()
    {
        MainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GatherInput();

        CheckStatus();

        ApplyMovement();

        ApplyGravity();
    }
    private void GatherInput()
    {
        Forward = Input.GetAxis("Horizontal");
        Side = Input.GetAxis("Vertical");
        Direction = new Vector3(Forward, 0, Side);
    }
    void CheckStatus()
    {
        if (!controller.isGrounded)
        {
            CurrentState = PlayerState.Falling;
        }
        else
        {
            if (Direction.magnitude <= 0.2f)
            {
                CurrentState = PlayerState.Idle;
            }
            else
            {
                CurrentState = PlayerState.Moving;
            }
        }
    }

    private void ApplyMovement()
    {
        if (CurrentState == PlayerState.Moving)
        {
            forwardSpeed = controller.velocity.z;
            sideSpeed = controller.velocity.x;
            float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + MainCam.transform.eulerAngles.y;

            var speedX = (Forward);
            var speedZ = (Side);

            Vector3 forward = MainCam.transform.forward;
            Vector3 right = MainCam.transform.right;

            forward.y = 0f;
            right.y = 0f;

            forward = forward.normalized;
            right = right.normalized;

            var relativeVector = (speedZ * forward) + (speedX * right);

            if (Direction.magnitude >= 0.2f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, targetAngle, 0), RotaSpeed * Time.deltaTime);
                controller.Move(new Vector3(relativeVector.x, Gravity, relativeVector.z) * RunSpeed * Time.deltaTime);
                smoothSpeed = Direction.magnitude;
                anim.SetFloat("HorizontalSpeed", smoothSpeed);
            }
          
        }
        if (CurrentState != PlayerState.Moving)
        {
            if (anim.GetFloat("HorizontalSpeed") > 0)
            {
                smoothSpeed -= Time.deltaTime*2;
                anim.SetFloat("HorizontalSpeed", smoothSpeed);
            }
            if (anim.GetFloat("HorizontalSpeed") <= 0)
            {
                anim.SetFloat("HorizontalSpeed", 0);
            }
        }

    }
    private void ApplyGravity()
    {
        if (CurrentState == PlayerState.Falling)
        {
            controller.Move(new Vector3(sideSpeed/1.5f, Gravity, forwardSpeed/1.5f) * Time.deltaTime);
            if (fallRate < 1)
            {
                fallRate += Time.deltaTime * 4;
                anim.SetFloat("VerticalSpeed", fallRate);
            }

        }
        else if (fallRate > 0)
        {
            fallRate -= Time.deltaTime * 4;
            anim.SetFloat("VerticalSpeed", fallRate);
        }
    }
}
