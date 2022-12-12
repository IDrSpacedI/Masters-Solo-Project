using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    //item name varibles
    public string name;
    public string description;
    public Sprite icon;

    public virtual void Use()
    {

    }
}
