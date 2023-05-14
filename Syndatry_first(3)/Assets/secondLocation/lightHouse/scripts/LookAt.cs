using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    [SerializeField] private Transform transformObject;
    [SerializeField] private Transform target;
    [Header("Оффсэты вращения")]
    public int x = 0;
    public int y = 0;
    public int z = 0;



    // Update is called once per frame
    void Update()
    {
        transformObject.LookAt(target);
        transformObject.Rotate(x, y, z);
    }
}
