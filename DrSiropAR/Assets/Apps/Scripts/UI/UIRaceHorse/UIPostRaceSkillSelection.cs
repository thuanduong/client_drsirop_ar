using System.ComponentModel;
using UnityEngine;
using TMPro;

public class UIPostRaceSkillSelection : PopupEntity<UIPostRaceSkillSelection.Entity>
{
    public class Entity
    {
        public UIToggleComponent.Entity toggle1;
        public UIToggleComponent.Entity toggle2;
        public UIToggleComponent.Entity toggle3;
        public UIToggleComponent.Entity toggle4;

        public string skillName1;
        public string skillName2;
        public string skillName3;
        public string skillName4;

        public ButtonEntity refreshButton;
        public ButtonEntity nextButton;
        public bool isSkillDetailVisible;
        public string skillDetail;
    }

    public UIToggleComponent toggle1;
    public UIToggleComponent toggle2;
    public UIToggleComponent toggle3;
    public UIToggleComponent toggle4;

    public TextMeshProUGUI skillName1;
    public TextMeshProUGUI skillName2;
    public TextMeshProUGUI skillName3;
    public TextMeshProUGUI skillName4;

    public UIButtonComponent refreshButton;
    public UIButtonComponent nextButton;

    public IsVisibleComponent isSkillDetailVisible;
    public TextMeshProUGUI skillDetail;
    
    protected override void OnSetEntity()
    {
        toggle1.SetEntity(entity.toggle1);
        toggle2.SetEntity(entity.toggle2);
        toggle3.SetEntity(entity.toggle3);
        toggle4.SetEntity(entity.toggle4);

        refreshButton.SetEntity(entity.refreshButton);
        nextButton.SetEntity(entity.nextButton);

        skillName1.SetText(entity.skillName1);
        skillName2.SetText(entity.skillName2);
        skillName3.SetText(entity.skillName3);
        skillName4.SetText(entity.skillName4);

        SetSkillDetail(entity.isSkillDetailVisible, entity.skillDetail);
    }

    public void SetSkillDetail(bool visible, string detail = "")
    {
        if (entity != default)
        {
            entity.isSkillDetailVisible = visible;
            entity.skillDetail = detail;
        }
        isSkillDetailVisible.SetEntity(visible);
        skillDetail.SetText(detail);
    }
}
