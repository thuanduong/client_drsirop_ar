using UnityEngine;
using TMPro;
using System.Linq;

public class UIPostRaceHorseIntroduce : PopupEntity<UIPostRaceHorseIntroduce.Entity>
{
    public class Entity
    {
        public ButtonEntity btnNext;
        public string horseName;
        public float Speed;
        public float Power;
        public float Stamina;
        public float Wits;
        public float Guts;
		public int Strategy;
    }
	
    public UIButtonComponent btnNext;
    public TextMeshProUGUI horseName;
    public FormattedTextComponent Speed;
    public FormattedTextComponent Power;
    public FormattedTextComponent Stamina;
    public FormattedTextComponent Wits;
    public FormattedTextComponent Guts;
	public System.Collections.Generic.List<GameObject> Strategies = new System.Collections.Generic.List<GameObject>();
    public System.Collections.Generic.List<GameObject> Skills = new System.Collections.Generic.List<GameObject>();


    protected override void OnSetEntity()
    {
        btnNext.SetEntity(entity.btnNext);
        SetHorseName(entity.horseName);
        SetHorseData(entity.Speed, entity.Power, entity.Stamina, entity.Wits, entity.Guts, entity.Strategy);
    }

    public void SetHorseData(float speed, float power, float stamina, float wits, float guts, int strategy)
    {
        if (entity != default)
        {
            entity.Speed = speed;
            entity.Power = power;
            entity.Stamina = stamina;
            entity.Wits = wits;
            entity.Guts = guts;
			entity.Strategy = strategy;
        }

        Speed.SetEntity(speed);
        Power.SetEntity(power);
        Stamina.SetEntity(stamina);
        Wits.SetEntity(wits);
        Guts.SetEntity(guts);
        setStrategy(strategy);

    }

    public void SetHorseName(string t)
    {
        if (this.entity != default) entity.horseName = t;
        horseName.SetText(t);
    }

    private void setStrategy(int ty)
    {
        for (int i = 0; i < Strategies.Count ; i++)
        {
            if (i == ty)
                Strategies[i].SetActive(true);
            else
                Strategies[i].SetActive(false);
        }
    }

    public void SetHorseSkill(int[] skills)
    {
        for (int i = 0; i < Skills.Count; i++)
        {
            if (skills != default && skills.Length > 0)
            {
                var aa = System.Convert.ToInt32(Skills[i].name);
                if (skills.Contains(aa))
                    Skills[i].SetActive(true);
                else
                    Skills[i].SetActive(false);
            }
            else
                Skills[i].SetActive(false);
        }
    }
}
