using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FightBehaviour : MonoBehaviour
{
    
    private CustomCharacterController _controllerManager;
    private HealthManager _healManager;


    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject cameraOld;
    [SerializeField] private GameObject cameraNew;

    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject fightCanvas;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private GameObject enemyHealthBar;
    private Animator anim;


    public int countOfRound = 0;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("videoCharacter") && (_controllerManager.Inventory.Count > 0))
        {
            //Отключаем управление и убираем анимацию
            anim.SetFloat("x", 0);
            anim.SetFloat("y", 0);
            _controllerManager.enabled = false;

            //Начинаем отсчет игры
            countOfRound = 1;

            //Меняем камеру и Canvas
            cameraOld.SetActive(false);
            mainCanvas.SetActive(false);
            cameraNew.SetActive(true);
            fightCanvas.SetActive(true);
            enemyHealthBar.SetActive(true);

        }
    }

    private void Start()
    {
        anim = player.GetComponent<Animator>();
        _controllerManager = player.GetComponent<CustomCharacterController>();
    }

    public void DeathEvent()
    {
        Destroy(player);

        deathCanvas.SetActive(true);
        fightCanvas.SetActive(false);
        mainCanvas.SetActive(false);

       
    }

    public void KillEvent()
    {
        cameraOld.SetActive(true);
        cameraNew.SetActive(false);
        mainCanvas.SetActive(true);
        enemyHealthBar.SetActive(false);
        _controllerManager.enabled = true;


        Destroy(this.gameObject);
    }

    public void AdminDie()
    {
        DeathEvent();
    }

    public void AdminKill()
    {
        KillEvent();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(2);
    }
}
