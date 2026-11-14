using UnityEngine;


class Interactable1 : Interactable 
{
   
    /// <summary>
    /// test to make sure an interactable can do things
    /// </summary>
    public override void InteractMethod()
    {
        Debug.Log("KILLYOURSELF!");
    }
}
