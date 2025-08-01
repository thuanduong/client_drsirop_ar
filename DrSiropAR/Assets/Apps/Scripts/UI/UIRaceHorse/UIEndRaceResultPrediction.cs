using UnityEngine;

public class UIEndRaceResultPrediction : PopupEntity<UIEndRaceResultPrediction.Entity>
{
    public class Entity {
        public string coin;
        public ButtonEntity btnProceed; 
    }

    public FormattedTextComponent coin;
    public UIButtonComponent btnProceed;

    protected override void OnSetEntity()
    {
        coin.SetEntity(entity.coin);
        btnProceed.SetEntity(entity.btnProceed);
    }
}
