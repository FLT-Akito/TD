using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSumon : MonoBehaviour
{

    public List<GameObject> summonerList;
    // private Dictionary<string, GameObject> summonPlayer = new Dictionary<string, GameObject>();
    public GameObject SummonArea { get; set; }
    private GameObject[] dropAreaObj;
    private SummonManger summonManger;

    private void Start()
    {
        dropAreaObj = GameObject.FindGameObjectsWithTag("SummonPlace");
        summonManger = new SummonManger();
        
    }



    public void SummonNumber(int index)
    {
        //Debug.Log(SummonArea.name);
        //Debug.Log(SummonArea.transform.position);
        foreach (GameObject obj in dropAreaObj)
        {
            obj.GetComponent<DropArea>().IsClicking = true;
        }

      

        if (summonManger.AddIndexNumber(index))
        {
            Instantiate(summonerList[index], SummonArea.transform.position, Quaternion.identity);
            UIController.Instance.panelSummonList.SetActive(false);
        }
       
    }

    //public void IsClick()
    //{

    //    foreach (GameObject obj in dropAreaObj)
    //    {
    //        obj.GetComponent<DropArea>().IsClicking = false;
    //    }

    //}
}
