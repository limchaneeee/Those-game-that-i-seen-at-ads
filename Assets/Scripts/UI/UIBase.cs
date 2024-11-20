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
}
    
    
