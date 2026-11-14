using UnityEngine;
using UnityEngine.UI;

class MapInteractable : Interactable
{
    [SerializeField] private Image map;


    /// <summary>
    /// display's map
    /// </summary>
    public override void InteractMethod()
    {
        flip = !flip;
        map.enabled = flip;
    }
}
