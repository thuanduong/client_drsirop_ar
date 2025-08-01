using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class UIPredictionHorseInfo : PopupEntity<UIPredictionHorseInfo.Entity>
{
    public class Entity
    {
        public int Id;
        public string Title;
        public int Speed;
        public int Power;
        public int Stamina;
        public int Wits;
        public int Guts;
        public int Color;
        public int Strategy;
        public ButtonEntity Button;
    }

    public TextMeshProUGUI Id;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI Power;
    public TextMeshProUGUI Stamina;
    public TextMeshProUGUI Wits;
    public TextMeshProUGUI Guts;
    public UIButtonComponent Button;
    public List<IsVisibleComponent> Strategies;

    protected override void OnSetEntity()
    {
        //Id.SetText(entity.Id.ToString());
        //Title.SetText(entity.Title);
        Speed.SetText(entity.Speed.ToString());
        Power.SetText(entity.Power.ToString());
        Stamina.SetText(entity.Stamina.ToString());
        Wits.SetText(entity.Wits.ToString());
        Guts.SetText(entity.Guts.ToString());

        Button.SetEntity(entity.Button);
        for(int i = 0; i < Strategies.Count; i++)
        {
            if (i == entity.Strategy)
                Strategies[i].SetEntity(true);
            else
                Strategies[i].SetEntity(false);
        }
    }
}
