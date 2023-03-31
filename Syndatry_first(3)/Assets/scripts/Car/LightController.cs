using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private List<GameObject> headLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            for (var i = 0; i < headLight.Count; i++)
            {
                if (headLight[i].activeInHierarchy)
                {
                    headLight[i].SetActive(false);
                } else
                {
                    headLight[i].SetActive(true);
                }
            }
        }
    }
}
