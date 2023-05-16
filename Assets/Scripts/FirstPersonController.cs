using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    //references
    public Transform cameraTransform;
    public CharacterController characterController;
    //player settings
    public float cameraSensitivity;
    public float moveSpeed;
    public float moveInputDeadZone;
    //Touch detection
    int leftFingerId, rightFingerId;
    float halfScreenWidth;
    //cam control
    Vector2 lookInput;
    float cameraPitch;
    //player movement
    Vector2 moveTouchStartPos;
    Vector2 moveInput;

    [SerializeField] private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
        // id = -1 means the finger is not being tracked
        leftFingerId = -1;
        rightFingerId = -1;

        //only calculate once
        halfScreenWidth = Screen.width / 2;

        //Debug.Log("Dead zone 1: " + moveInputDeadZone);
        //calculate the movement input dead zone
        moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);
        //Debug.Log("Dead zone 2: " + moveInputDeadZone);
        
    }

    // Update is called once per frame
    void Update()
    {       
        GetTouchInput();

        //only look around if the right finger is being tracked
        if (rightFingerId != -1)
        {
            Debug.Log("Rotating");
            LookAround();
        }
        if (leftFingerId != -1)
        {
            Debug.Log("Moving");
            Move();
        } 
    }
    void GetTouchInput()
    {
        // itterate though all touches detected
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            //check each touch's position
            switch (t.phase)
            {
                case TouchPhase.Began:
                    if (t.position.x < halfScreenWidth && leftFingerId == -1)
                    {
                        //start tracking the left finger if it wasn't already being tracked
                        leftFingerId = t.fingerId;
                        //set the start pos for move control finger
                        moveTouchStartPos = t.position;
                    }
                    else if (t.position.x > halfScreenWidth && rightFingerId == -1)
                    {
                        //start tracking the right finger if it isnt already being tracked
                        rightFingerId = t.fingerId;
                    }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (t.fingerId == leftFingerId)
                    {
                        //stop tracking left finger
                        leftFingerId = -1;
                        anim.SetFloat("Speed_f", 0f);
                        anim.SetInteger("Animation_int", 0);
                        Debug.Log("Stopped tracking left finger");
                    }
                    else if (t.fingerId == rightFingerId)
                    {
                        //stop tracking right finger
                        rightFingerId = -1;
                        Debug.Log("Stopped tracking right finger");
                    }
                    break;
                case TouchPhase.Moved:
                    //get input for looking around
                    if(t.fingerId == rightFingerId)
                    {
                        lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
                    }
                    else if (t.fingerId == leftFingerId)
                    {
                        //calculating the position delta from the start pos
                        moveInput = t.position - moveTouchStartPos;
                    }
                    break;
                case TouchPhase.Stationary:
                    if(t.fingerId == rightFingerId)
                    {
                        lookInput = Vector2.zero;
                        // idle anim 
                    }
                    break;
            }
        }
    }
    void LookAround()
    {
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        transform.Rotate(transform.up, lookInput.x);
    }
    void Move()
    {
        //if speed = 0, idle anim
        //dont move if the touch delta is shorter than the designated dead zone
        if (moveInput.sqrMagnitude <= moveInputDeadZone)
        {
            anim.SetFloat("Speed_f", 0f);
            anim.SetInteger("Animation_int", 0);
            Debug.Log("DedZone");
            return;
        }

        anim.SetFloat("Speed_f", 0.3f);
        //multiply the normalized direction by the speed
        Vector2 movementDirection = moveInput.normalized * moveSpeed * Time.deltaTime;
        Debug.Log("Normalise");
        //move relatively to the local transforms direction
        characterController.Move(transform.right * movementDirection.x + transform.forward * movementDirection.y);
        Debug.Log("Moving Relative");
        
    }
}
