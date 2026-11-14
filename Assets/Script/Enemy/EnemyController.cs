using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerRef;
    private Rigidbody2D rb;

    //movement refs
    [SerializeField]
    private float maxSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       rb.MovePosition(transform.position + Seek(playerRef.transform.position) * Time.fixedDeltaTime);
    }

    private Vector3 Seek(Vector3 targetPos)
    {
        Vector3 desiredVel = targetPos - transform.position;

        desiredVel = desiredVel.normalized * maxSpeed;

        Vector3 seekForce = desiredVel - new Vector3(rb.linearVelocityX, rb.linearVelocityY, 0);

        return seekForce;
    }

}
