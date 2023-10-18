using UnityEngine;

public class PlantGrowth2D : MonoBehaviour
{
    public float maxGrowth = 1.0f;
    public float currentGrowth = 0.0f;

    public void WaterPlant(float amount)
    {
        // Increment the current growth by the watering amount
        currentGrowth += amount;

        // Ensure that the current growth doesn't exceed the maximum growth
        currentGrowth = Mathf.Clamp(currentGrowth, 0.0f, maxGrowth);
    }

    public bool IsFullyGrown()
    {
        return Mathf.Approximately(currentGrowth, maxGrowth);
    }
}
