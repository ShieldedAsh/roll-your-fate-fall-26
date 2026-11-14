using UnityEngine;

abstract class Interactable : MonoBehaviour
{
    /// <summary>
    /// Standard method the interact method calls from the interactable target
    /// </summary>
    public abstract void InteractMethod();
}
