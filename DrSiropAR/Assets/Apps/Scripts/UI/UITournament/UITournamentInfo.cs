using UnityEngine;

public class UITournamentInfo : PopupEntity<UITournamentInfo.Entity>
{
    public class Entity
    {
        public ButtonEntity Button;
    }

    public UIButtonComponent Button;

    protected override void OnSetEntity()
    {
        Button.SetEntity(entity.Button);
    }
}
