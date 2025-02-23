using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChampionSelectionSprite : MonoBehaviour
{
    public ChampionsDataSprite[] championsData;
    public Transform championGridParent; // Parent for champion buttons
    public GameObject championButtonPrefab; // Prefab for champion icons

    public TMP_Text championNameText;
    public Image championIconImage;
    public Button lockInButton;
    public TMP_Text timerText;

    private int selectedChampionIndex = -1;
    private float countdown = 60f;
    private bool isLockedIn = false;

    private void Start()
    {
        PopulateChampionGrid();
        UpdateChampionDisplay(0); // Default selection
    }

    private void Update()
    {
        if (!isLockedIn)
        {
            countdown -= Time.deltaTime;
            timerText.text = Mathf.Ceil(countdown).ToString();

            if (countdown <= 0)
            {
                LockInChampion();
            }
        }
    }

    private void PopulateChampionGrid()
    {
        foreach (ChampionsDataSprite champ in championsData)
        {
            GameObject btn = Instantiate(championButtonPrefab, championGridParent);
            btn.GetComponent<Image>().sprite = champ.championIcon;
            btn.GetComponent<Button>().onClick.AddListener(() => UpdateChampionDisplay(System.Array.IndexOf(championsData, champ)));
            TMP_Text tmp = Instantiate(championNameText, championGridParent);
            tmp.GetComponent<TMP_Text>().text = champ.championName;
        }
    }

    public void UpdateChampionDisplay(int index)
    {
        if (index < 0 || index >= championsData.Length) return;

        selectedChampionIndex = index;
        championNameText.text = championsData[index].championName;
        championIconImage.sprite = championsData[index].championIcon;
    }

    public void LockInChampion()
    {
        if (selectedChampionIndex < 0) return;

        isLockedIn = true;
        lockInButton.interactable = false;
        Debug.Log($"Champion {championsData[selectedChampionIndex].championName} locked in!");
    }
}

