using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectsScriptableObject kitchenObjectsSO;
 
    

    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {//There isn't kitchen object here 

            if(player.HasKitchenObject())
            {
                //Player carrying something.
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player not carrying anything
            }
        }else
        {
             //There is a kitchen object here
             if(player.HasKitchenObject())
            {
                //Player carrying something
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //Player holding plate

                   
                   if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                   
                }else
                {
                    //Player not carrying plate but something else 
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // Counter holding a plate
                        if(plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
             else
            {
                //Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
     
    }

}


