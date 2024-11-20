using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTitle : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.Show<TitleText>();
    }
}
