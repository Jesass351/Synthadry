using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    //����������� �� ����
    private static Image _healthBarImage;
    //����������� ���� ����
    private static Image _shieldBarImage;
    //����� ��� ����������� ���� ��
    [SerializeField] private TextMeshProUGUI _healthInfo;
    //����� ��� ����������� ���� ����
    [SerializeField] private TextMeshProUGUI _shieldInfo;

    // ��� ������
    void Awake()
    {
        // ����������� ��������� ���� ���� �������� �� ����
        _healthBarImage = transform.GetChild(0).GetComponent<Image>();
        // ����������� ��������� ���� ���� �������� ���� ����
        _shieldBarImage = transform.GetChild(1).GetComponent<Image>();
    }

    //�������� ������ �� ����
    public void UpdateHealthBarStatus(int currentHP, int maxHP)
    {
        //����������� ����� ��������� �� � ��������� ����� �������� � ������������ �� ����
        _healthBarImage.fillAmount = (float)currentHP / maxHP;
        //������ �������� � ������
        _healthInfo.text = currentHP+"/"+maxHP;
    }

    public void UpdateShieldBarStatus(int currentShield, int maxShield)
    {
        //����������� ����� ��������� ���� � ��������� ����� �������� � ������������ ���� ����
        _shieldBarImage.fillAmount = (float)currentShield / maxShield;
        //������ �������� � ������
        _shieldInfo.text = currentShield + "/" + maxShield;
    }
}
