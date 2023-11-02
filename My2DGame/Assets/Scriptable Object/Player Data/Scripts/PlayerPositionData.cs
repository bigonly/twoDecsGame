using UnityEngine;

[CreateAssetMenu (fileName = "LocationName", menuName = "Player/Location/Position")]
public class PlayerPositionData : ScriptableObject
{
    [Header("Location Name")]
    public string LocationName = "Write here location name";
    [TextArea]
    public string LocationDescription = "Write here description where player must save their position";
    [Header("Player Position")]
    public Vector3 Position;
    [Header("Save Player Position")]
    public bool savePlayerPosition;
}
