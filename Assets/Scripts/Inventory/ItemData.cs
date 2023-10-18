using UnityEngine;
using UnityEngine.Tilemaps;


public class ItemData : MonoBehaviour
{

    [Header("Only gameplay")]

    public string name;
    public ItemType type;

    public ActionType actionType;

    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]

    public bool stackable = true;

    [Header("Both")]

    public Sprite image;

    public enum ItemType
    {
        Food,
        Seed,
        Tool
    }

    public enum ActionType
    {
        plant,
        Heal,
        Sell,
        water
    }
}

   