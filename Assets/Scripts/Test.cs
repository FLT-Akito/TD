using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    public Transform startPosi;
    public Transform endPosi;

    public float speed = 1.0f;
    private float direction;

    private void Start()
    {
        direction = Vector2.Distance(startPosi.position, endPosi.position);
    }

    private void Update()
    {
        float present_location = (Time.time * speed) / direction;

        transform.position = Vector2.Lerp(startPosi.position, endPosi.position, present_location);
       
    }
}
