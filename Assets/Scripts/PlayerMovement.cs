using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;

    private float x;
    private float z;
    private float velocitySpeed;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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

        if (Input.GetMouseButtonDown(0))
        {
            //ScreenPointToRay is converting the Vector2 position of the mouse into
            //Vector 3 position of the character (shoots a ray from the mouse position into the game world)
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out hit))
            {
                nav.destination = hit.point;
            }
        }

        if(velocitySpeed != 0)
        {
            anim.SetBool("sprinting", true);
        }

        if (velocitySpeed == 0)
        {
            anim.SetBool("sprinting", false);
        }

    }
}
