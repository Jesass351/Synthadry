using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]private int _maxHealth;//������������ ��
    [SerializeField]private int _currentHealth;//������� ��
    [SerializeField]private HealthBarHandler _healthBarHandler;//������ � �������� �� ����

    private void Awake()
    {
        //��������, ��� ����. �� ������ 0, ����� ������
        if (_maxHealth <= 0)
        {
            Debug.LogError("����. �� = 0");
            Debug.Break();
        }

        //������ ������� �� ������ ������������� ��
        if (_currentHealth > _maxHealth)
            _maxHealth = _currentHealth;
    }

    private void Start()
    {
        //��������� ������ ��� ������� ����
        _healthBarHandler.UpgradeHealthBarStatus(_currentHealth, _maxHealth);
    }


    void Update()
    {
        //���������, ����� ������� �� �� ���� ������ �������������
        if (_currentHealth > _maxHealth)
            _maxHealth = _currentHealth;
    }

    //����� ��������� ����� � ���������� �� ����
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Debug.Log("������!");
            _currentHealth = 0;
        }
            _healthBarHandler.UpgradeHealthBarStatus(_currentHealth, _maxHealth);
    }

    //����� �������������� �������� � ���������� �� ����
    public void TakeHeal(int heal)
    {
        _currentHealth += heal;
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        _healthBarHandler.UpgradeHealthBarStatus(_currentHealth, _maxHealth);
    }

    //���������� ���� �� 
    public void RecountMaxHealth(int adder)
    {
        _maxHealth += adder;
        _healthBarHandler.UpgradeHealthBarStatus(_currentHealth, _maxHealth);
    }

}
