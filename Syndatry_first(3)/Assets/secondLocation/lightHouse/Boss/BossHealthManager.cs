
using UnityEngine;
using UnityEngine.UI;

public class BossHealthManager : MonoBehaviour
{

    [SerializeField] private float health = 100;
    [SerializeField] private float damage;

    [SerializeField] private Image hpLine;
    [SerializeField] private GameObject fightCanvas;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        hpLine.fillAmount = (health / 100);
    }

    private void OnDestroy()
    {
        Debug.Log("Вмер");
    }

    private void OnEnable()
    {
        fightCanvas.SetActive(true);
    }

    private void OnDisable()
    {
        fightCanvas.SetActive(false);
    }
}
