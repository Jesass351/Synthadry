using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject jbj = GameObject.Find("videoCharacter");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        CustomCharacterController playerScript = other.GetComponent<CustomCharacterController>();
        //Animator animator = other.GetComponent<Animator>();
        if (other.gameObject.name.Equals("videoCharacter"))
        {
            Animator animator = other.GetComponent<Animator>();
            playerScript.enabled = false;
            //Animation animator2 = animator.GetComponent<Animation>();
            //animator.Play("Walking");
            animator.enabled = false;
        }
    }
}
