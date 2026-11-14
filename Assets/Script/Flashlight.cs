using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private Light2D coneLight; //light infront of you: the "flashlight"
    [SerializeField]
    private Light2D areaLight; //light that surrounds you: "area light"

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
