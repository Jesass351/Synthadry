
using UnityEngine;

[CreateAssetMenu(fileName = "New Component", menuName = "Create new Component")]
[System.Serializable]

public class Component : ScriptableObject
{
    public string componentName;

    public string description;

    public Sprite icon;

    public enum Types
    {
        fuel,
        cloth,
        scrap,
        plastic,
        chemBasis,
        wires
    };

    public Types type;

}
