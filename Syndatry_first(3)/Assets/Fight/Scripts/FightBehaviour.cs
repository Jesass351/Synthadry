using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FightBehaviour : MonoBehaviour
{
    
    private CustomCharacterController _controllerManager;

    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject cameraOld;
    [SerializeField] private GameObject cameraNew;

    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject fightCanvas;
    [SerializeField] private GameObject adminBtns;
    [SerializeField] private GameObject deathCanvas;
    private Animator anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("videoCharacter"))
        {
            //Меняем камеру и Canvas
            cameraOld.SetActive(false);
            mainCanvas.SetActive(false);
            cameraNew.SetActive(true);
            fightCanvas.SetActive(true);
            adminBtns.SetActive(true);


            //Отключаем управление и убираем анимацию
            anim.SetFloat("x", 0);
            anim.SetFloat("y", 0);
            _controllerManager.enabled = false;

            

        }
    }

    private void Start()
    {
        anim = player.GetComponent<Animator>();
        _controllerManager = player.GetComponent<CustomCharacterController>();
    }

    private void DeathEvent()
    {
        Destroy(player);

        deathCanvas.SetActive(true);
        fightCanvas.SetActive(false);
        mainCanvas.SetActive(false);
       
    }

    private void KillEvent()
    {
        cameraOld.SetActive(true);
        cameraNew.SetActive(false);
        mainCanvas.SetActive(true);
        adminBtns.SetActive(false);

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
