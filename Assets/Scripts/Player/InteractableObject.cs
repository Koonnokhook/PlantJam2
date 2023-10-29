using UnityEngine;
using static PlantAbility;

public enum InteractionType
{
    getWater,
    waterPlant,
    plantSeed,
    harvest
    // Add more interaction types as needed
}

public class InteractableObject : MonoBehaviour, Interactive.IInteractable
{
    public InteractionType interactionType;
    public SpriteRenderer sinkSpriteRenderer;
    public int maxWaterUses = 3;
    private int remainingWaterUses;

    public InventoryManager inventoryManager;
    PlantVariety selectedVariety = PlantAbility.Instance.plantVarieties[0];

    public PotScript potScript; // Attach the script to the pot GameObject
    public GameObject seedPrefab; // The prefab of the seed

    private void WaterPlant(int waterNeeded)
    {
        // Implement watering logic here.
        if (remainingWaterUses > 0)
        {
            // Change the sprite of the sink to indicate that it's being used.
            if (sinkSpriteRenderer != null)
            {
                // Set the sprite to a "used" state.
                // You should prepare the appropriate sprites in your project.
                // You can change the sprite using sinkSpriteRenderer.sprite.
            }

            // Perform the watering action (e.g., increment a plant's water level).
            // You can also include code for plant growth here.

            // Reduce the remaining water uses.
            remainingWaterUses--;

            // Check if there's no more water.
            if (remainingWaterUses <= 0)
            {
                // You can disable the interaction with the sink or change its state.
                // Optionally, change the sprite back to its original state.
                if (sinkSpriteRenderer != null)
                {
                    // Reset the sprite to its original state.
                    // You should prepare the appropriate sprites in your project.
                    // You can change the sprite using sinkSpriteRenderer.sprite.
                }
            }
        }
        else
        {
            // Implement logic for when there is no more water.
            // You can display a message to the player or perform other actions.
        }
    }

    public void Interact()
    {
        // Implement interaction logic based on the interaction type.
        switch (interactionType)
        {
            case InteractionType.getWater:
                GetWater();
                break;
            case InteractionType.plantSeed:
                PlantSeed();
                break;
            case InteractionType.waterPlant:
                WaterPlant(plantVariety.needWatered);
                break;
                // Add more cases for additional interaction types
        }
    }

    private void GetWater()
    {
        GameObject waterBucketPrefab = inventoryManager.GetWaterBucketPrefab(); // Replace with the actual method
        if (inventoryManager.HasItem(waterBucketPrefab))
        {
            // Handle the interaction when the water bucket is in the inventory
            // For example, you can water plants or perform other actions using the water bucket.
            // Implement the logic based on your game's mechanics.
            WaterPlant(plantVariety.needWatered);
        }
        else
        {
            // Assuming that the Player has a script with a water supply, e.g., WaterSupplyScript
            WaterSupplyScript playerWaterSupply = GetComponent<WaterSupplyScript>();
            if (playerWaterSupply != null)
            {
                // Access the selected plant variety
                int selectedPlantIndex = 0; // You need to set this based on the player's selection
                PlantVariety selectedPlant = PlantVarietiesGetter.GetSelectedPlantVariety(selectedPlantIndex);

                if (selectedPlant != null)
                {
                    int waterNeeded = selectedPlant.needWatered;

                    if (playerWaterSupply.HasEnoughWater(waterNeeded))
                    {
                        // Deduct water from the player's supply
                        playerWaterSupply.DeductWater(waterNeeded);

                        // Now you can use the water to water plants or perform other actions
                        WaterPlant(waterNeeded);
                    }
                    else
                    {
                        // Implement logic for when the player doesn't have enough water
                        //display message you need to get more water
                    }
                }
            }
        }
    }

    private void PlantSeed()
    {
        // Check if the pot is empty and if there are seeds in the inventory
        if (potScript.IsEmpty() && inventoryManager.HasItem(seedPrefab))
        {
            // Plant a seed in the pot
            potScript.PlantSeed(seedPrefab);

            // Remove the planted seed from the inventory
            inventoryManager.RemoveItem(seedPrefab);
        }
        else
        {
            // Handle cases where the pot is not empty or there are no seeds in the inventory
            // You can display messages or perform other actions as needed.
        }
    }
}
