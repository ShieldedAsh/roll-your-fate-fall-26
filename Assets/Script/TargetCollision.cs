using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("WinScene");
        }
        if (!collision.gameObject.CompareTag("Enviornment"))
        {
            Debug.Log("in");
            isColliding = true;
        }

    }

    /// <summary>
    /// quite remarkable that if two colliders overlap, transfering betwee the two prios exit over enter
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("WinScene");
        }
        if (!collision.gameObject.CompareTag("Enviornment"))
        {
            Debug.Log("in");
            isColliding = true;
        }
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
