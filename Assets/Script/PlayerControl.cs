using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Vector2 moveDirection;



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

        }
        else if (moveDirection.x < 0)
        {
            //left arrow
        }

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
