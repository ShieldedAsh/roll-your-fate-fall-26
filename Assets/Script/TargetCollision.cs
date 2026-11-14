using Unity.VisualScripting;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] GameObject target;
    public bool isColliding = false;

    /// <summary>
    /// checks if something has entered the trigger radius
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("in");
        isColliding = true;
    }

    /// <summary>
    /// checks if something has exited the trigger radius
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Out");
        isColliding = false;
    }

    /// <summary>
    /// if the child is also a target, check if it is colliding and update this one to colliding
    /// </summary>
    private void Update()
    {
        if (!target.IsUnityNull())
        {
            isColliding = target.GetComponent<TargetCollision>().isColliding;
        }
    }
}
