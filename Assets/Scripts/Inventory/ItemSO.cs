using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum ItemType { Consumable, Equipment }

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class ItemSO : ScriptableObject
{
    public string ID;
    public string Name;
    public TileBase Tile;
    public Sprite Sprite;
    public ItemType Type;
    public bool Stackable;

    public void UseItem()
    {
        Debug.Log("Using " + Name + " ... now removing it.");
    }
}