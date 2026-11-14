using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Vector2 moveDirection;
    private float playerAngle = 0;
    private float rotSpeed = 22.5f;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
        moveDirection.Normalize();

        //x 
        if (moveDirection.x > 0)
        {
            //right arrow
            playerAngle -= rotSpeed;

        }
        else if (moveDirection.x < 0)
        {
            //left arrow
            playerAngle += rotSpeed;
        }

        gameObject.transform.rotation = Quaternion.Euler(0, 0, playerAngle);

        if (moveDirection.y > 0)
        {
            //up arrow

        }
        else if (moveDirection.y < 0)
        {
            //down arrow

        }
        //y

    }

    public void OnInteract(InputAction.CallbackContext context)
    {

    }

    public void OnAttack(InputAction.CallbackContext context) 
    {

    }
}
