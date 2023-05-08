using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class CustomCharacterController : MonoBehaviour
{
    [SerializeField] private Transform aimTarget;
    public float aimLerp;
    public float multy;

    [Header("RifleRigs")]
    [SerializeField] private MultiAimConstraint rigRifle;

    [SerializeField] private List<WeaponBehaviour> inventory = new List<WeaponBehaviour>();
    public List<WeaponBehaviour> Inventory
    {
        get { return inventory; }

        set { inventory = value; }
    }


    private List<WeaponBehaviour> inventoryForDeb = new List<WeaponBehaviour>();
    public List<WeaponBehaviour> InventoryForDeb
    {
        get { return inventoryForDeb; }

        set { inventoryForDeb = value; }
    }

    public Canvas canvas;

    public Animator anim;
    public Rigidbody rig;
    public Transform mainCamera;
    public float jumpForce = 3.5f;
    public float walkingSpeed = 10f;
    public float runningSpeed = 15f;
    public float currentSpeed;
    private float animationInterpolation = 1f;
    public FixedJoystick joystick;
    public float horisontal;
    public float vertical;
    private float lerpMulti = 7f;

    public bool canGo = true;
    public bool isRunning = false;


    private CharacterController characterController;

    private InventorySystem inventorySystem;

    private string activeMainWeaponName;

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        characterController = GetComponent<CharacterController>();
        inventorySystem = GetComponent<InventorySystem>();
        this.GetComponent<CustomCharacterController>().enabled = false;
        this.GetComponent<CustomCharacterController>().enabled = true;
    }

    public void UpdateMainGunName(string name)
    {
        activeMainWeaponName = name;
    }
    void Run()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);
        anim.SetFloat("x", horisontal * animationInterpolation);
        anim.SetFloat("y", vertical * animationInterpolation);

        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
        SetRigWeight(0);
        anim.SetBool("RifleRunning", true);
        isRunning = true;
    }
    public void Walk()
    {
        // Mathf.Lerp - отвчает за то, чтобы каждый кадр число animationInterpolation(в данном случае) приближалось к числу 1 со скоростью Time.deltaTime * 3.
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1f, Time.deltaTime * 3);
        anim.SetFloat("x", horisontal * 0.25f);
        anim.SetFloat("y", vertical * 0.25f);

        //currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);
        currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, Time.deltaTime * 3);

        SetRigWeight(1);
        anim.SetBool("RifleRunning", false);
        isRunning = false;
    }

    void SetRigWeight(float weight, string name = "AK")
    {

        switch (name)
        {
            case "AK":
                rigRifle.weight = weight;
                break;
        }
    }

    private void Update()
    {

        Ray desiredTargetRay = mainCamera.gameObject.GetComponent<Camera>().ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Vector3 desiredTargetPosition = desiredTargetRay.origin + desiredTargetRay.direction * multy;
        aimTarget.position = Vector3.Lerp(aimTarget.position, desiredTargetPosition, aimLerp * Time.deltaTime);
        /*        aimTarget.position = desiredTargetPosition;*/
        /* if (canGo)
         {
             horisontal = Input.GetAxis("Horizontal") * animationInterpolation;
             vertical = Input.GetAxis("Vertical") * animationInterpolation;
             //horisontal = Mathf.Lerp(horisontal, joystick.Horizontal, Time.deltaTime * lerpMulti);
             //vertical = Mathf.Lerp(vertical, joystick.Vertical, Time.deltaTime * lerpMulti);
             // ”станавливаем поворот персонажа когда камера поворачиваетс€ 
             transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
             // «ажаты ли кнопки W и Shift?
             if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
             {
                 // «ажаты ли еще кнопки A S D?
                 //Debug.Log("aaaa");
                 if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                 {
                     // ≈сли да, то мы идем пешком
                     Walk();
                 }
                 // ≈сли нет, то тогда бежим!
                 else
                 {
                     Run();
                 }
             }
             // ≈сли W & Shift не зажаты, то мы просто идем пешком
             else
             {
                 Walk();
             }
             //≈сли зажат пробел, то в аниматоре отправл€ем сообщение тригеру, который активирует анимацию прыжка
             if (Input.GetKeyDown(KeyCode.Space))
             {
                 anim.SetTrigger("Jump");
             }
         }
         else
         {
             horisontal = 0;
             vertical = 0;
             currentSpeed = 0;
         } */


        horisontal = Input.GetAxis("Horizontal") * animationInterpolation;
        vertical = Input.GetAxis("Vertical") * animationInterpolation;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        /*        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                    {
                        rigRifle.weight = 1f;
                        anim.SetBool("RifleRunning", false);
                        Walk();
                    }
                    else
                    {

                    }
                }*/
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)) && Input.GetKey(KeyCode.LeftShift))
        {

            Run();
        }
        else
        {
            rigRifle.weight = 1;
            anim.SetBool("RifleRunning", false);
            Walk();
        }

        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        /*  // «десь мы задаем движение персонажа в зависимости от направлени€ в которое смотрит камера
          // —охран€ем направление вперед и вправо от камеры 
          Vector3 camF = mainCamera.forward;
          Vector3 camR = mainCamera.right;
          // „тобы направлени€ вперед и вправо не зависили от того смотрит ли камера вверх или вниз, иначе когда мы смотрим вперед, персонаж будет идти быстрее чем когда смотрит вверх или вниз
          // ћожете сами проверить что будет убрав camF.y = 0 и camR.y = 0 :)
          camF.y = 0;
          camR.y = 0;
          Vector3 movingVector;
          // “ут мы умножаем наше нажатие на кнопки W & S на направление камеры вперед и прибавл€ем к нажати€м на кнопки A & D и умножаем на направление камеры вправо
          movingVector = Vector3.ClampMagnitude(camF.normalized * vertical * currentSpeed + camR.normalized * horisontal * currentSpeed, currentSpeed);
          // Magnitude - это длинна вектора. € делю длинну на currentSpeed так как мы умножаем этот вектор на currentSpeed на 86 строке. я хочу получить число максимум 1.
          anim.SetFloat("magnitude", movingVector.magnitude / currentSpeed);
          //Debug.Log(movingVector.magnitude / currentSpeed);
          // «десь мы двигаем персонажа! ”станавливаем движение только по x & z потому что мы не хотим чтобы наш персонаж взлетал в воздух
          rig.velocity = new Vector3(movingVector.x, rig.velocity.y, movingVector.z);
          // ” мен€ был баг, что персонаж крутилс€ на месте и это исправил с помощью этой строки
          rig.angularVelocity = Vector3.zero;*/


        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        camF.y = 0;
        camR.y = 0;
        Vector3 movingVector;
        movingVector = Vector3.ClampMagnitude(camF.normalized * vertical * currentSpeed + camR.normalized * horisontal * currentSpeed, currentSpeed);
        anim.SetFloat("magnitude", movingVector.magnitude / currentSpeed);

        if (!characterController.isGrounded)
        {
            movingVector.y -= walkingSpeed * 2;
        }



        /*  RaycastHit hit;  //  арабканье по вертикальным стенам тест
          if (Physics.Raycast(transform.position, transform.forward, out hit, 2f)) //&& hit.normal.y <= 0.1f)
          {
              movingVector = Vector3.up * walkingSpeed;
          }

          */


        characterController.Move(movingVector * Time.fixedDeltaTime);

    }
    public void Jump()
    {
        /* // ¬ыполн€ем прыжок по команде анимации.
         rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);*/

        if (characterController.isGrounded)
        {
            characterController.Move(Vector3.up * jumpForce * Time.fixedDeltaTime);
        }
    }
}