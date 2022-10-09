using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]private int _maxHealth;//максимальное хп
    [SerializeField]private int _currentHealth;//текущее хп
    [SerializeField]private HealthBarHandler _healthBarHandler;//скрипт с визуалом хп бара

    private void Awake()
    {
        //проверка, что макс. хп больше 0, иначе ошибка
        if (_maxHealth <= 0)
        {
            Debug.LogError("Макс. ХП = 0");
            Debug.Break();
        }

        //делаем текущее хп равное максимальному хп
        if (_currentHealth > _maxHealth)
            _maxHealth = _currentHealth;
    }

    private void Start()
    {
        //обновляем статус при запуске лвла
        _healthBarHandler.UpgradeHealthBarStatus(_currentHealth, _maxHealth);
    }


    void Update()
    {
        //проверяем, чтобы текущее хп не было больше максимального
        if (_currentHealth > _maxHealth)
            _maxHealth = _currentHealth;
    }

    //метод получение урона и обновления хп бара
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Debug.Log("Смерть!");
            _currentHealth = 0;
        }
            _healthBarHandler.UpgradeHealthBarStatus(_currentHealth, _maxHealth);
    }

    //метод восстановления здоровья и обновления хп бара
    public void TakeHeal(int heal)
    {
        _currentHealth += heal;
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        _healthBarHandler.UpgradeHealthBarStatus(_currentHealth, _maxHealth);
    }

    //перерасчёт макс хп 
    public void RecountMaxHealth(int adder)
    {
        _maxHealth += adder;
        _healthBarHandler.UpgradeHealthBarStatus(_currentHealth, _maxHealth);
    }

}
