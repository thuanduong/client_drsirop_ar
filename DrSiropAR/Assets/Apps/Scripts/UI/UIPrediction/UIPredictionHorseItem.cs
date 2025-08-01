using UnityEngine;
using TMPro;

public class UIPredictionHorseItem : UIComponent<UIPredictionHorseItem.Entity>
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
        public System.Action<int> Button;
    }

    public TextMeshProUGUI Id;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI Power;
    public TextMeshProUGUI Stamina;
    public TextMeshProUGUI Wits;
    public TextMeshProUGUI Guts;
    public UIButtonComponent Button;

    private void Start()
    {
        Button.SetEntity(new ButtonEntity(OnButtonClicked));
    }

    protected override void OnSetEntity()
    {
        Id.SetText(entity.Id.ToString());
        Title.SetText(entity.Title);
        Speed.SetText(entity.Speed.ToString());
        Power.SetText(entity.Power.ToString());
        Stamina.SetText(entity.Stamina.ToString());
        Wits.SetText(entity.Wits.ToString());
        Guts.SetText(entity.Guts.ToString());

        
    }

    void OnButtonClicked()
    {
        if (entity != default)
            entity.Button.Invoke(entity.Id);
    }
}
