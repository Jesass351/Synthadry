using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Torch : MonoBehaviour
{
    [SerializeField] private GameObject UIRemaindCounter;
    [SerializeField] private int percentPerSecond;
    [SerializeField] private double currentRemaind = 100f;

    [SerializeField] private GameObject particles;

    void FixedUpdate()
    {
        if (particles.activeInHierarchy)
        {
            currentRemaind = currentRemaind - (0.02 * percentPerSecond);
            UIRemaindCounter.GetComponent<TextMeshProUGUI>().text = Math.Round(currentRemaind).ToString();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (particles.activeInHierarchy)
            {
                particles.SetActive(false);
            }
            else
            {
                particles.SetActive(true);
            }
        }
    }

    public void addPercentages(int count)
    {
        currentRemaind = Math.Min(currentRemaind + count, 100);
    }
}
