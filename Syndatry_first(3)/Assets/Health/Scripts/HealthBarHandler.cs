using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    //изображение хп бара
    private static Image _healthBarImage;
    //изображение бара щита
    private static Image _shieldBarImage;
    //текст для отображения цифр хп
    [SerializeField] private TextMeshProUGUI _healthInfo;
    //текст для отображения цифр щита
    [SerializeField] private TextMeshProUGUI _shieldInfo;

    // При старте
    void Awake()
    {
        // Присваиваем закрытому полю нашу картинку хп бара
        _healthBarImage = transform.GetChild(0).GetComponent<Image>();
        // Присваиваем закрытому полю нашу картинку щита бара
        _shieldBarImage = transform.GetChild(1).GetComponent<Image>();
    }

    //изменяем статус хп бара
    public void UpdateHealthBarStatus(int currentHP, int maxHP)
    {
        //высчитываем новое отношение хп и установка этого значения в наполненость хп бара
        _healthBarImage.fillAmount = (float)currentHP / maxHP;
        //меняем значение в тексте
        _healthInfo.text = currentHP+"/"+maxHP;
    }

    public void UpdateShieldBarStatus(int currentShield, int maxShield)
    {
        //высчитываем новое отношение щита и установка этого значения в наполненость щита бара
        _shieldBarImage.fillAmount = (float)currentShield / maxShield;
        //меняем значение в тексте
        _shieldInfo.text = currentShield + "/" + maxShield;
    }
}
