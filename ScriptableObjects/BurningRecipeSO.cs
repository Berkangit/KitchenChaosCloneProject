using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject
{
    public KitchenObjectsScriptableObject input;
    public KitchenObjectsScriptableObject output;
    public float burningTimerMax;
}
