using UnityEngine;

public class UIEndRaceHorseResult : PopupEntity<UIEndRaceHorseResult.Entity>
{
    public class Entity {
        public UIEndRaceResultItem.Entity[] List;
        public ButtonEntity btnProceed;
        public ButtonEntity btnReplay;
        public UIImageComponent.Entity first;
        public UIImageComponent.Entity second;
        public UIImageComponent.Entity third;
    }

    public UIEndRaceResultListItem List;
    public UIButtonComponent btnProceed;
    public UIButtonComponent btnReplay;
    public UIImageComponent first;
    public UIImageComponent second;
    public UIImageComponent third;


    protected override void OnSetEntity()
    {
        List.SetEntity(entity.List);
        btnProceed.SetEntity(entity.btnProceed);
        btnReplay.SetEntity(entity.btnReplay);

        first.SetEntity(entity.first);
        second.SetEntity(entity.second);
        third.SetEntity(entity.third);
    }
}
