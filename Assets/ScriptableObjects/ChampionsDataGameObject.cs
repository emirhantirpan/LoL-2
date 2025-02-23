using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject/ChampionsData", menuName = "ChampionsDataGameObject", order = 1)]
public class ChampionsDataGameObject : ScriptableObject
{
    public string championName;
    public string championRange;
    public string championPopLane;
    public GameObject championObject;

}
