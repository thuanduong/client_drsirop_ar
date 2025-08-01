using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class UICommentRacingHorse : PopupEntity<UICommentRacingHorse.Entity>
{
    public class Entity 
    {
        public float delay;
    }

    public TextMeshProUGUI Detail;
    public CanvasGroup commentGroup;

    private bool isShowingSubtitle;
    Queue<SubtitleEvent> subtitleQueue = new Queue<SubtitleEvent>();
    Coroutine c;

    protected override void OnSetEntity()
    {
    }

    private struct SubtitleEvent
    {
        public string text;
        public float duration;
    }

    public void EnqueueSubtitle(string text, float duration)
    {
        
        subtitleQueue.Enqueue(new SubtitleEvent { text = text, duration = duration });
        if (!isShowingSubtitle)
        {
            c = StartCoroutine(ProcessSubtitleQueue());
        }
    }

    public void Stop()
    {
        if (c != default)
            StopCoroutine(c);
        subtitleQueue.Clear();
        isShowingSubtitle = false;
        commentGroup.alpha = 0.0f;
        Detail.text = "";
    }

    private IEnumerator ProcessSubtitleQueue()
    {
        commentGroup.alpha = 1.0f;
        isShowingSubtitle = true;
        while (subtitleQueue.Count > 0)
        {
            SubtitleEvent currentSubtitle = subtitleQueue.Dequeue();
            yield return ShowSubtitleCoroutine(currentSubtitle.text, currentSubtitle.duration);
            yield return new WaitForSeconds(entity.delay);
        }
        isShowingSubtitle = false;
        c = default;
        commentGroup.alpha = 0.0f;
    }

    private IEnumerator ShowSubtitleCoroutine(string text, float duration)
    {
        if (Detail != null)
        {
            Detail.text = text;

            yield return new WaitForSeconds(duration);

            Detail.text = "";
        }
    }


}
