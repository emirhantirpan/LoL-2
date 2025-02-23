using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class ChampionSelectionGameObject : MonoBehaviour
{
    public ChampionsDataGameObject[] championsDatas;
    public Transform spot;

    private List<GameObject> champions;
    private int currentChamp;

    public TMP_Text championName;
    public TMP_Text championRange;
    public TMP_Text championPopLane;

    private void Start()
    {
        champions = new List<GameObject>();

        foreach (var champ in championsDatas)
        {
            GameObject champion = Instantiate(champ.championObject, spot.position, transform.rotation);
            champion.SetActive(false);
            champion.transform.SetParent(spot);
            champions.Add(champion);
        }

        ShowChampFromList();
    }
    private void ShowChampFromList()
    {
        champions[currentChamp].SetActive(true);
        championName.text = championsDatas[currentChamp].championName;
        championRange.text = championsDatas[currentChamp].championRange;
        championPopLane.text = championsDatas[currentChamp].championPopLane;
    }
    public void OnClickNext()
    {
        champions[currentChamp].SetActive(false);
        if (currentChamp < champions.Count -1)
        {
            currentChamp = currentChamp + 1;
        }
        else
        {
            currentChamp = 0;
        }
        ShowChampFromList();
    }
    public void OnClickPrev()
    {
        champions[currentChamp].SetActive(false);
        if (currentChamp == 0)
        {
            currentChamp = champions.Count - 1;
        }
        else
        {
            currentChamp = currentChamp - 1;
        }
        ShowChampFromList();
    }
}
