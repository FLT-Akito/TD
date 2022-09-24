using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropArea : MonoBehaviour
{
    private PlayerSumon playerSumon;
    public bool IsClicking { get; set; } = true;
    //public CircleCollider2D Circle { get; set; }
    //private CircleCollider2D circle;
    //public GameObject clickedGameObject;


    private void Start()
    {
        playerSumon = GameObject.Find("PlayerSumoner").GetComponent<PlayerSumon>();
        
    }

    private void OnMouseDown()
    {

        //clickedGameObject = null;  

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);

        //if (hit2d)
        //{
        //    clickedGameObject = hit2d.transform.gameObject;
        //}
        //Debug.Log(this.gameObject.name);
        //if(IsClicking)
        //{
           
        //    //Debug.Log(playerSumon.SummonArea.name);
        //}
        playerSumon.SummonArea = this.gameObject;
        UIController.Instance.panelSummonList.SetActive(true);
        //playerSumon.IsClick();

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    PlayerBase player = collision.gameObject.GetComponent<PlayerBase>();
    //    if (player != null)
    //    {
    //        player.SetMoveTarget(transform.position);
    //       // collision.transform.position = transform.position;
    //    }
    //}

}
