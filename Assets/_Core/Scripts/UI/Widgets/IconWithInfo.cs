using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class IconWithInfo : MonoBehaviour
{
    public TextMeshProUGUI text;

    private int currentValue;
    private Tween animTween;

    public void Init()
    {
        currentValue = 0;
        text.text = currentValue.ToString();
    }
    
    public void SetText(string _text)
    {
        text.text = _text;
    }
    
    public void UpdateValue(int _newValue)
    {
        if (animTween.IsActive())
        {
            animTween.Kill();
        }
        
        animTween = transform.DOPunchPosition(new Vector3(0, 4, 0), 0.25f);
        DOTween.To(() => currentValue, x => currentValue = x, _newValue, 0.5f).OnUpdate(OnAnimUpdate);
    }

    private void OnAnimUpdate()
    {
        text.text = currentValue.ToString();
    }
}
