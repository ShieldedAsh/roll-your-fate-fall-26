using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private Light2D coneLight; //light infront of you: the "flashlight"
    [SerializeField]
    private Light2D areaLight; //light that surrounds you: "area light"

    [SerializeField]
    public float lightTimer = 100f;

    // Update is called once per frame
    void Update()
    {
        if (lightTimer <= 0.0f)
        {
            coneLight.intensity = 0.0f;
            areaLight.pointLightOuterRadius = 2.0f;
        }
        else if (lightTimer <= 25.0f)
        {
            coneLight.intensity = 0.25f;
            areaLight.pointLightOuterRadius = 2.25f;
            lightTimer -= Time.deltaTime;
        }
        else if (lightTimer <= 50.0f)
        {
            coneLight.intensity = 0.5f;
            areaLight.pointLightOuterRadius = 2.5f;
            lightTimer -= Time.deltaTime;
        }
        else if (lightTimer <= 75.0f)
        {
            coneLight.intensity = 0.75f;
            areaLight.pointLightOuterRadius = 2.75f;
            lightTimer -= Time.deltaTime;
        }
        else
        {
            lightTimer -= Time.deltaTime;
            coneLight.intensity = 1.0f;
            areaLight.pointLightOuterRadius = 3.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            Debug.Log("enter");
            lightTimer += 25.0f;
            Destroy(other.gameObject);
        }
    }
}
