using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectsScriptableObject kitchenObjectSO;
    }
    [SerializeField] private List<KitchenObjectsScriptableObject> validKitchenObjectSOList;

    private List<KitchenObjectsScriptableObject> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectsScriptableObject>();
    }
    public bool TryAddIngredient(KitchenObjectsScriptableObject kitchenObjectsSO)
    {
        if(!validKitchenObjectSOList.Contains(kitchenObjectsSO))
        {
            // nOT VALid ingredient
            return false;
        }
        if(kitchenObjectSOList.Contains(kitchenObjectsSO))
        {
            //Aldread has this type 
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectsSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectsSO
            });
            return true;
        }
        

    }

    public List<KitchenObjectsScriptableObject> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
