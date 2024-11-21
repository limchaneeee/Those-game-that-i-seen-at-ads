using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Transform canvas;

    public static float ScreenWidth = 760;
    public static float ScreenHeight = 1280;
    
    [HideInInspector]
    public List<UIBase> uiList = new List<UIBase>();
    

    public T Show<T>() where T : UIBase
    {
        string uiName = typeof(T).ToString();
        UIBase go = Resources.Load<UIBase>("UI/" + uiName);
        var ui = Load<T>(go, uiName);
        uiList.Add(ui);
        ui.Opened();

        return (T)ui;
    }

    private T Load<T>(UIBase prefab, string uiName) where T : UIBase
    {
        GameObject newCavasObj = new GameObject(uiName + "Canvas");
        
        var canvas = newCavasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        var canvasScaler = newCavasObj.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(ScreenWidth, ScreenHeight);

        newCavasObj.AddComponent<GraphicRaycaster>();
        
        UIBase ui = Instantiate(prefab, newCavasObj.transform);
        ui.name = uiName.Replace("(Clone)", "");
        ui.canvas = canvas;
        ui.canvas.sortingOrder = (uiList == null ? 0 : uiList.Count);

        return (T)ui;
    }

    private void Hide<T>() where T : UIBase
    {
        string uiName = typeof(T).ToString();
        Hide(uiName);
    }

    public void Hide(string uiName)
    {
        UIBase go = uiList.Find(obj=> obj.name == uiName);
        if (uiList.Count != 0)
        {
            uiList.Remove(go);
        }
        Destroy(go.canvas.gameObject);
    }

    public void ClearAllUI()
    {
        foreach (var ui in uiList)
        {
            Destroy(ui.canvas.gameObject);
        }
        uiList.Clear();
    }
}
