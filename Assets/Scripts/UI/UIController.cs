using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    public GameObject panelSummonList;
    //public GameObject HpBar;
    public GameObject fireMagicIcon;
    public GameObject iceMagicIcon;
    public GameObject thunderMagicIcon;

    private void Awake()
    {
        Instance = this;
    }

    public void CloseSummonPanelList()
    {
        panelSummonList.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
