using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDailyMoney : PopupEntity<UIDailyMoney.Entity>
{
    [System.Serializable]
    public class Entity
    {
        public ButtonEntity NextBtn;
		public string Money;
    }

    public FormattedTextComponent Money;
    public UIButtonComponent NextBtn;

    protected override void OnSetEntity()
    {
        NextBtn.SetEntity(this.entity.NextBtn);
		Money.SetEntity(this.entity.Money);
    }
}
