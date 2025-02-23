using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject/ChampionsData", menuName = "ChampionsDataSprite", order = 2)]
public class ChampionsDataSprite : ScriptableObject
{
    public string championName;
    public Sprite championIcon;

}
