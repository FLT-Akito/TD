using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonListPanel : MonoBehaviour
{
    [SerializeField] GameObject gameLayerMask;

    private void OnEnable()
    {
        gameLayerMask.SetActive(true);
    }

    private void OnDisable()
    {
        gameLayerMask.SetActive(false);
    }
}
