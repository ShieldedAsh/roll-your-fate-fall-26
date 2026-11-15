using UnityEngine;

public class ebverMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector2 velocity;

    private Vector2 pos;
    private float rotSpeed;

    private float angle;

    void Start()
    {
        GodSourge(); GodSourge2();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10)
        {
            GodSourge();
        }
        if (transform.position.y > 7 || transform.position.y < -7)
        {
            GodSourge();
        }

        pos.x = pos.x + (velocity.x * Time.deltaTime) * 3;

        pos.y = pos.y + (velocity.y * Time.deltaTime) * 3;

        transform.position = new Vector3(pos.x, pos.y, 0);
        angle += rotSpeed * Time.deltaTime;
        transform.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }


    private void GodSourge()
    {
        pos.y = Random.Range(-5, 5);
        pos.x = -10;
        velocity.x = Random.Range(1, 100);
        velocity.y = Random.Range(-4, 4);
        velocity.Normalize();

        rotSpeed = Random.Range(-45, 45);
    }
    private void GodSourge2()
    {
        pos.y = Random.Range(-5, 5);
        pos.x = Random.Range(-8, 8); ;

    }
}
