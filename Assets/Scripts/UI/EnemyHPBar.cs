using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Transform camPos;
    [SerializeField] private Image fillImage;
    [SerializeField] private Enemy enemy;

    private void Start()
    {
        camPos = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(transform.position + camPos.rotation * Vector3.forward, camPos.rotation * Vector3.up);
    }

    public void UpdateHPBar()
    {
        float health = enemy.health;
        float maxHealth = enemy.Data.EnemyData.EnemyMaxHp;

        fillImage.fillAmount = health / maxHealth;
    }
}
