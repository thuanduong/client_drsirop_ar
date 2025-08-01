using UnityEngine;
using TMPro;

public class UIPredictionMoney : UIComponent<UIPredictionMoney.Entity>
{
    public class Entity
    {
        public UIToggleComponent.Entity toggle;
        public string money;
    }

    public UIToggleComponent toggle;
    public TextMeshProUGUI money;

    protected override void OnSetEntity()
    {
        toggle.SetEntity(entity.toggle);
        money.SetText(entity.money);
    }
}
