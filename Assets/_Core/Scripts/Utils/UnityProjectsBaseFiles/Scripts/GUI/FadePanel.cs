using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public static FadePanel Ins;

    public Image panel;
    void Awake() => Ins = this;

    private UnityAction fadeItCallback, fadeOutCallback;
    
    // * =====================================================================================================================================
    // * IN 
    
    public void FadeIn(float _time = 1, UnityAction _callback = null)
    {
        fadeItCallback = _callback;
        panel.DOFade(1, _time)
            .SetEase(Ease.Linear)
            .OnComplete(OnFadeInComplete);
    }

    private void OnFadeInComplete() => fadeItCallback?.Invoke();

    // * =====================================================================================================================================
    // * OUT
    
    public void FadeOut(float time = 1, UnityAction _callback = null)
    {
        panel.DOFade(0, time)
            .SetEase(Ease.Linear)
            .OnComplete(OnFadeOutComplete);
    }

    private void OnFadeOutComplete() => fadeOutCallback?.Invoke();
}
