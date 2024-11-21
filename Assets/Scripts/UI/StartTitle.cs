using UnityEngine;

public class StartTitle : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.Show<TitleText>();
    }
}
