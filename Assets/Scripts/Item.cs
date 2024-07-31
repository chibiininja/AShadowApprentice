using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Item/CreateNewItem")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string addNoise;
    public string removeNoise;
}
