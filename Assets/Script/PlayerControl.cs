using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Vector2 moveDirection;
    private Vector3 startingPos;
    private float playerAngle = 0;
    private float teleportAngle = 0;
    private float rotSpeed = 45f;
    private float teleportDistance = 0;
    private int teleportMod = 1;


    //target.mp3
    [SerializeField] private GameObject teleportTarget;
    [SerializeField] private GameObject camma;
    [SerializeField] private GameObject lite;

    private Vector2 targetTransform = Vector2.zero;

    private Interactable lastInteract;


    void Start()
    {
        startingPos = transform.position;
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
        lite.gameObject.transform.rotation = Quaternion.Euler(0, 0, playerAngle);

        if (moveDirection.y > 0)
        {
            //up arrow
            teleportDistance += 8f * teleportMod * Time.deltaTime;
        }
        else if (moveDirection.y < 0)
        {
            //down arrow
            teleportAngle -= (rotSpeed/(5+ (teleportDistance*7))) * Time.deltaTime;
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
    /// casts a ray to see if an interactable is in range and has the interactable tag
    /// </summary>
    /// <param name="context"></param>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // do better i dare you
            lite.gameObject.transform.rotation = Quaternion.Euler(0, 0, playerAngle + 45);

            Vector2 foward = (lite.gameObject.transform.rotation * new Vector3(1, 1, 0)).normalized;

            lite.gameObject.transform.rotation = Quaternion.Euler(0, 0, playerAngle - 45);
            //

            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, foward);

            for (int i = 0;  i < hit.Length; i++)
            {
                if (hit[i].collider.gameObject.CompareTag("Interactable") && hit[i].distance < 1)
                {
                    hit[i].collider.GetComponent<Interactable>().InteractMethod();
                    lastInteract = hit[i].collider.GetComponent<Interactable>();
                    break;
                }
            }
        }
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

            if (teleportTarget.GetComponent<TargetCollision>().isColliding)
            {
                PlayerDies();
            }
            else
            {
                if (lastInteract != null && lastInteract.GetComponent<Interactable>().flip)
                {
                    lastInteract.GetComponent<Interactable>().InteractMethod();
                    lastInteract = null;
                }

                if (lastInteract != null)
                {
                    lastInteract = null;
                }
                gameObject.transform.position = targetTransform;
                camma.gameObject.transform.position = new Vector3(targetTransform.x, targetTransform.y, -10);

                teleportDistance = 0;
            }

        }
    }

    internal void PlayerDies()
    {
        SceneManager.LoadScene("GaeJoever");
        gameObject.transform.position = startingPos;
        camma.gameObject.transform.position = new Vector3(startingPos.x, startingPos.y, -10);
        teleportDistance = 0;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            PlayerDies();
        }
    }
}
