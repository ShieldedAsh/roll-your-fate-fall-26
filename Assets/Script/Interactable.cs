using UnityEngine;

abstract class Interactable : MonoBehaviour
{
    internal bool flip = false;



    /// <summary>
    /// Standard method the interact method calls from the interactable target
    /// </summary>
    public abstract void InteractMethod();
}
