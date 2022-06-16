using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;

    private float x;
    private float z;
    private float velocitySpeed;

    CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 mousePos;
    private Vector3 currentMousePos;

    public static bool canMove = true;
    //var "moving" prevents the shopUI from dissapearing
    public static bool moving = false;
    //moveLayer is necessary for the raycast to ignore the BuildingTrigger collider
    public LayerMask moveLayer;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currentMousePos = ct.m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate velocity speed

        //Adding x and z is necessary, so that the velocitySpeed during movement is never 0 and
        //the Animator can set the bool "sprinting" to true or false
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;

        //Get mouse position
        mousePos = Input.mousePosition;
        ct.m_FollowOffset = currentMousePos;

        if (Input.GetMouseButtonDown(0))
        {
            if(canMove == true)
            {
                //ScreenPointToRay is converting the Vector2 position of the mouse into
                //Vector 3 position of the character (shoots a ray from the mouse position into the game world)
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 300, moveLayer))
                {
                    nav.destination = hit.point;
                }
            }  
        }

        if(velocitySpeed != 0)
        {
            anim.SetBool("sprinting", true);
            moving = true;
        }

        if (velocitySpeed == 0)
        {
            anim.SetBool("sprinting", false);
            moving = false;
        }

        if (Input.GetMouseButton(1))
        {
            if(mousePos.x != 0 || mousePos.y != 0)
            {
                currentMousePos = mousePos / 200;
            }
        }

    }
}
