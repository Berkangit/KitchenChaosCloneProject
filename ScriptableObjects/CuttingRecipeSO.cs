using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
    public KitchenObjectsScriptableObject input;
    public KitchenObjectsScriptableObject output;
    public int cuttingProgressMax;
}
