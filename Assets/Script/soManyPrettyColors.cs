using UnityEngine;

public class soManyPrettyColors : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float i = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i += .5f * Time.deltaTime;

        gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(i, .5f, 1);
        if (i > 1)
        {
            i = 0;
        }
    }
}
