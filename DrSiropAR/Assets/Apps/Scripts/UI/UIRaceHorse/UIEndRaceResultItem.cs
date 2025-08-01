using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class UIEndRaceResultItem : UIComponent<UIEndRaceResultItem.Entity>
{
    public class Entity 
    {
        public string PlayerName;
        public string Record;
        public int Rank;
        public int RankIndex;
        public int ColorIndex;
    }

    public TextMeshProUGUI PlayerName;
    public TextMeshProUGUI Record;

    public TextMeshProUGUI Rank;
    public List<GameObject> Ranks;    
    public List<GameObject> BackgroundImages;

    protected override void OnSetEntity()
    {
        PlayerName.SetText(entity.PlayerName);
        Record.SetText(entity.Record);
        Rank.text = entity.Rank.ToString();
        for (int i = 0; i < Ranks.Count; i++)
        {
            if (i == entity.RankIndex)
                Ranks[i].SetActive(true);
            else
                Ranks[i].SetActive(false);
            
        }

        for (int i = 0; i < BackgroundImages.Count; i++)
        {
            if (i == entity.ColorIndex)
                BackgroundImages[i].SetActive(true);
            else
                BackgroundImages[i].SetActive(false);
        }
    }
}
