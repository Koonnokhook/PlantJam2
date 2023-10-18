using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmingSystem : MonoBehaviour, Interactive.IInteractable
{
    public GameObject grownPlantPrefab;
    public Transform plantBed;
    public PlantType plantType;
    public PlantGrowth2D plantGrowth;

    private GameObject currentPlant;
    private float growthProgress;
    private bool isGrowing;
    private int daysWatered;
    private Animator animator;

    public float wateringAmount = 0.1f;
    public LayerMask plantLayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (!isGrowing && currentPlant == null)
        {
            PlantSeed();
        }
        else if (!isGrowing && currentPlant != null && daysWatered < 1)
        {
            WaterPlant();
        }
    }

    private void Update()
    {
        if (isGrowing)
        {
            growthProgress += Time.deltaTime;

            if (growthProgress >= GetGrowthTime())
            {
                isGrowing = false;
                GrowPlant();
            }
        }
    }


    private float GetGrowthTime()
    {
        if (currentPlant != null)
        {
            //var variety = plantType.GetPlantVarieties()[1];
            //return variety.growthTime;
        }

        return 0f;
    }


    private void PlantSeed()
    {
        // Implement logic for planting a seed
    }

    private void GrowPlant()
    {
        if (currentPlant != null)
        {
            currentPlant.transform.localScale *= 1.2f;

            SpriteRenderer plantRenderer = currentPlant.GetComponent < SpriteRenderer>();

            if (plantRenderer != null)
            {
                // Calculate growth progress based on the in-game time and growth time
                float growthProgress = Time.time / GetGrowthTime();
                growthProgress = Mathf.Clamp01(growthProgress); // Ensure it's between 0 and 1.

                // Update the plant's growth stage
                //UpdatePlantGrowth(growthProgress);
            }
        }
    }

    private void WaterPlant()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.up;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 2f, plantLayer);

        if (hit.collider != null)
        {
            PlantGrowth2D plant = hit.collider.GetComponent<PlantGrowth2D>();

            if (plant != null)
            {
                plant.WaterPlant(wateringAmount);
            }
        }
    }

    public void Harvest()
    {
        if (plantGrowth.IsFullyGrown()) 
        {
            /*if(growthTime >= growthTimeRequired && watered >= needWatered)
            {

                return;
            }*/
            SceneManager.LoadScene("TurnBase"); // Replace "BattleScene" with the actual name of your battle scene.
        }
    }
}
