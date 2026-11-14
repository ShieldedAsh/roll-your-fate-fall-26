using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Vector2 moveDirection;
    private float playerAngle = 0;
    private float teleportAngle = 0;
    private float rotSpeed = 45f;
    private float teleportDistance = 0;
    private int teleportMod = 1;

    //target.mp3
    [SerializeField] private GameObject teleportTarget;
    [SerializeField] private GameObject camera;

    private Vector2 targetTransform = Vector2.zero;




    void Start()
    {
        
    }

    
    void Update()
    {
        if (moveDirection.x > 0 )
        {
            //right arrow
            playerAngle -= rotSpeed * Time.deltaTime ;

        }
        else if (moveDirection.x < 0 )
        {
            //left arrow
            playerAngle += rotSpeed * Time.deltaTime;
        }

        //changes player rotation for interaction reasons
        gameObject.transform.rotation = Quaternion.Euler(0, 0, playerAngle);

        if (moveDirection.y > 0)
        {
            //up arrow
            teleportDistance += .003f * teleportMod;
        }
        else if (moveDirection.y < 0)
        {
            //down arrow
            teleportAngle -= (rotSpeed/(5+ (teleportDistance*10))) * Time.deltaTime;
        }

        //A bunch of math to alter the teleport target's position
        targetTransform.x = teleportDistance * (float)Math.Cos(teleportAngle) + gameObject.transform.position.x;
        targetTransform.y = teleportDistance * (float)Math.Sin(teleportAngle) + gameObject.transform.position.y;
        teleportTarget.transform.position = targetTransform;
        
        //flips the growth/decay of the target if it hits a bounds
        if (teleportDistance > 7 || teleportDistance < 0)
        {
            teleportMod *= -1;
        }
        
    }


    /// <summary>
    /// alters the move direction vector based on player input
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
        moveDirection.Normalize();
    }

    /// <summary>
    /// TODO: make interaction
    /// </summary>
    /// <param name="context"></param>
    public void OnInteract(InputAction.CallbackContext context)
    {

    }

    /// <summary>
    /// Teleports the player to the target, also resets the teleport target's distance
    /// </summary>
    /// <param name="context"></param>
    public void OnAttack(InputAction.CallbackContext context) 
    {
        if (context.started)
        {
            //Teleport!

            if (!teleportTarget.GetComponent<TargetCollision>().isColliding)
            {
                //Die!
            }

            gameObject.transform.position = targetTransform;
            camera.gameObject.transform.position = targetTransform;
            teleportDistance = 0;
        }
    }
}
