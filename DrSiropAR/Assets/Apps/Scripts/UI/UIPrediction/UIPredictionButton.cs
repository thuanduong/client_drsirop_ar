using UnityEngine;
using TMPro;

public class UIPredictionButton : UIComponent<UIPredictionButton.Entity>
{
    public class Entity {
        public int id;
        public System.Action<int> Button = ActionUtility.EmptyAction<int>.Instance;
        public string Name;
        public string Rate;
        public string Prediction;
    }

    public UIButtonComponent Button;
    public FormattedTextComponent Name;
    public FormattedTextComponent Rate;
    public TextMeshProUGUI Prediction;

    private void Start()
    {
        Button.SetEntity(new ButtonEntity(onButtonClick));
    }

    protected override void OnSetEntity()
    {
        Name.SetEntity(entity.Name);
        Rate.SetEntity(entity.Rate);
        Prediction.SetText(entity.Prediction);
    }
    
    protected void onButtonClick()
    {
        entity.Button?.Invoke(entity.id);
    }

    public void SetPrediction(string val)
    {
        if (entity != null) entity.Prediction = val;
        Prediction.SetText(val);
    }

}
