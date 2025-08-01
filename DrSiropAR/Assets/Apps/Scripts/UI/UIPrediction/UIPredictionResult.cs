using UnityEngine;

public class UIPredictionResult : PopupEntity<UIPredictionResult.Entity>
{
    public class Entity
    {
        public ButtonEntity btnViewRace;
    }

    public UIButtonComponent btnViewRace;

    protected override void OnSetEntity()
    {
        btnViewRace.SetEntity(entity.btnViewRace);
    }
}
