using UnityEngine;

public class UIPostRaceStategySelection : PopupEntity<UIPostRaceStategySelection.Entity>
{
    public class Entity
    {
        public UIToggleComponent.Entity toggle1;
        public UIToggleComponent.Entity toggle2;
        public UIToggleComponent.Entity toggle3;
        public UIToggleComponent.Entity toggle4;

        public ButtonEntity nextButton;
    }

    public UIToggleComponent toggle1;
    public UIToggleComponent toggle2;
    public UIToggleComponent toggle3;
    public UIToggleComponent toggle4;

    public UIButtonComponent nextButton;

    protected override void OnSetEntity()
    {
        toggle1.SetEntity(entity.toggle1);
        toggle2.SetEntity(entity.toggle2);
        toggle3.SetEntity(entity.toggle3);
        toggle4.SetEntity(entity.toggle4);

        nextButton.SetEntity(entity.nextButton);
    }
}
