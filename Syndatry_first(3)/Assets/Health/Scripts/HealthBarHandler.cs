using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    //изображение хп бара
    private static Image _healthBarImage;
    //текст для отображения цифр хп
    [SerializeField] private TextMeshProUGUI _healthInfo;
    
    // При старте
    void Start()
    {
        // Присваиваем закрытому полю нашу картинку хп бара
        _healthBarImage = transform.GetChild(0).GetComponent<Image>();
    }

    //изменяем статус хп бара
    public void UpgradeHealthBarStatus(int currentHP, int maxHP)
    {
        //высчитываем новое отношение хп и установка этого значения в наполненость хп бара
        _healthBarImage.fillAmount = (float)currentHP / maxHP;
        //меняем значение в тексте
        _healthInfo.text = currentHP+"/"+maxHP;
    }
}
