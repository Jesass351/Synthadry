using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator PlayerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleLayers(string layer, float state)
    {
        PlayerAnimation.SetLayerWeight(PlayerAnimation.GetLayerIndex(layer), state);
    }

    public float GetLayerStatus(string layer)
    {
        return PlayerAnimation.GetLayerWeight(PlayerAnimation.GetLayerIndex(layer));
    }

    void RifleAim(int state)
    {
        if (state == 1)
        {
            PlayerAnimation.SetBool("RifleAiming", true);
        } else
        {
            PlayerAnimation.SetBool("RifleAiming", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RifleAim(1);
        }
        if (Input.GetMouseButtonUp(1))
        {
            RifleAim(0);
        }
    }
}
