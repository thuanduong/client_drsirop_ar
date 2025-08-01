using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPrediction : PopupEntity<UIPrediction.Entity>
{
    public class Entity
    {
        public int Size;
        public UIPredictionListButton.Entity listOne;
        public UIPredictionColumnList.Entity listTwo;
        public UIPredictionMoneyToggleList.Entity listMoney;
        public UIPredictionHorseListItem.Entity listHorse;
        public string countdownText;
    }

    public UIPredictionListButton listOne;
    public UIPredictionColumnList listTwo;
    public UIPredictionMoneyToggleList listMoney;
    public UIPredictionHorseListItem listHorse;

    public TextMeshProUGUI countdownText;

    public RectTransform Content;
    public ExcelScrollRectComponent scrollRect;
    public ScrollRect ScrollRect;
    [SerializeField] float Space;


    protected override void OnSetEntity()
    {
        listOne.SetEntity(entity.listOne);
        listTwo.SetEntity(entity.listTwo);
        listMoney.SetEntity(entity.listMoney);
        listHorse.SetEntity(entity.listHorse);
        countdownText.SetText(entity.countdownText);
        updateSize();
    }

    private void updateSize()
    {
        Content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Space * entity.Size);
    }


    public async UniTask DirtyAsync(CancellationToken cancellationToken)
    {
        if (scrollRect != null)
            await scrollRect.Dirty(cancellationToken: cancellationToken);

        if (ScrollRect != null)
            ScrollRect.enabled = false;
        await UniTask.Delay(200, cancellationToken: cancellationToken);
        if (ScrollRect != null)
            ScrollRect.enabled = true;
    }

    public void UpdateCountDown(string value)
    {
        if (entity != null) entity.countdownText = value;
        if (countdownText != null) countdownText.SetText(value);
    }
}
