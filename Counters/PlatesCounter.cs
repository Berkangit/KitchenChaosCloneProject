using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;  
    public event EventHandler OnPlateRemowed;  
    [SerializeField] private KitchenObjectsScriptableObject plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int plateSpawnedAmount;
    private int plateSPawnedAmountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;

        if( spawnPlateTimer > spawnPlateTimerMax)
        {
           spawnPlateTimer = 0;

            if(KitchenGameManager.Instance.IsGamePlaying() &&  plateSpawnedAmount < plateSPawnedAmountMax)
            {
                plateSpawnedAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }

        }
    }

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {
            // Player is empty hand

            if(plateSpawnedAmount > 0)
            {
                //There is at least 1 plate on platescounter 

                plateSpawnedAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemowed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
