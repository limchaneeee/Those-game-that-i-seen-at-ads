using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIBase : MonoBehaviour
{
    public Canvas canvas;

    protected virtual void Awake()
    {
        if (canvas == null)
            canvas = GetComponent<Canvas>();
    }

    public virtual void Opened()
    {
    }

    public virtual void Hide()
    {
        UIManager.Instance.Hide(gameObject.name);
    }

    public virtual void PopUpAnimaition()
    {
        transform.localScale = Vector3.one * 0.1f;
        
        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.2f, 0.7f));
        seq.Append(transform.DOScale(1f, 0.1f));
        seq.Play();
    }

    public virtual void CloseAnimation()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.2f, 0.1f));
        seq.Append(transform.DOScale(0.1f, 0.7f));
        seq.Play();
    }
}
    
    
