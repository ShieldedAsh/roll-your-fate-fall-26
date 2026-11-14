using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    public bool isColliding = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("in");
        isColliding = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Out");
        isColliding = false;
    }
}
