using UnityEngine;
using TMPro;

public class UIPostRaceHorseSelection : PopupEntity<UIPostRaceHorseSelection.Entity>
{
    public class Entity
    {
        public ButtonEntity btnSelect;
        public ButtonEntity btnStart;
        public ButtonEntity btnNext;
        public ButtonEntity btnPrev;
        public string horseNumber;
        public string horseName;
        public float Speed;
        public float Power;
        public float Stamina;
        public float Wits;
        public float Guts;
    }

    public UIButtonComponent btnSelect;
    public UIButtonComponent btnStart;
    public UIButtonComponent btnNext;
    public UIButtonComponent btnPrev;
    public TextMeshProUGUI horseNumber;
    public TextMeshProUGUI horseName;
    public FormattedTextComponent Speed;
    public FormattedTextComponent Power;
    public FormattedTextComponent Stamina;
    public FormattedTextComponent Wits;
    public FormattedTextComponent Guts;

    protected override void OnSetEntity()
    {
        btnSelect.SetEntity(entity.btnSelect);
        btnStart.SetEntity(entity.btnStart);
        btnNext.SetEntity(entity.btnNext);
        btnPrev.SetEntity(entity.btnPrev);
        horseNumber.SetText(entity.horseNumber);
        SetHorseName(entity.horseName);
        SetHorseData(entity.Speed, entity.Power, entity.Stamina, entity.Wits, entity.Guts);
    }

    public void SetHorseNumber(string t)
    {
        if (this.entity != default) entity.horseNumber = t;
        horseNumber.SetText(t);
    }

    public void SetHorseData(float speed, float power, float stamina, float wits, float guts)
    {
        if (entity != default)
        {
            entity.Speed = speed;
            entity.Power = power;
            entity.Stamina = stamina;
            entity.Wits = wits;
            entity.Guts = guts;
        }

        Speed.SetEntity(speed);
        Power.SetEntity(power);
        Stamina.SetEntity(stamina);
        Wits.SetEntity(wits);
        Guts.SetEntity(guts);

    }

    public void SetHorseName(string t)
    {
        if (this.entity != default) entity.horseName = t;
        horseName.SetText(t);
    }
}
