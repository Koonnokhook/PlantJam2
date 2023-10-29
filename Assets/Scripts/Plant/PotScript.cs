using UnityEngine;

public class PotScript : MonoBehaviour
{
    private bool isEmpty = true; // Track whether the pot is empty or not

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public void PlantSeed(GameObject seedPrefab)
    {
        if (isEmpty)
        {
            // Instantiate the seed prefab and place it in the pot
            Instantiate(seedPrefab, transform.position, Quaternion.identity, transform);

            // Update the state to indicate that the pot is not empty
            isEmpty = false;
        }
        else
        {
            // Handle the case where the pot is already occupied (e.g., display a message)
        }
    }
}
