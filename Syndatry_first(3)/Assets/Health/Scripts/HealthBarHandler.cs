using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    //����������� �� ����
    private static Image _healthBarImage;
    //����� ��� ����������� ���� ��
    [SerializeField] private TextMeshProUGUI _healthInfo;
    
    // ��� ������
    void Start()
    {
        // ����������� ��������� ���� ���� �������� �� ����
        _healthBarImage = transform.GetChild(0).GetComponent<Image>();
    }

    //�������� ������ �� ����
    public void UpgradeHealthBarStatus(int currentHP, int maxHP)
    {
        //����������� ����� ��������� �� � ��������� ����� �������� � ������������ �� ����
        _healthBarImage.fillAmount = (float)currentHP / maxHP;
        //������ �������� � ������
        _healthInfo.text = currentHP+"/"+maxHP;
    }
}
