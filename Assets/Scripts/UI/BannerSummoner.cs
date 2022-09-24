using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerSummoner : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public Image summonImage;
    public Image rarityFrame;
    public Text skillText;
    public Text summonName;
    public Text summonLevel;
   
    void Start()
    {
        if(playerStatus != null)
        {
            Show(playerStatus);
        }
    }

    private void Show(PlayerStatus status)
    {
        skillText.text = status.Description;
        summonName.text = status.Name;
        summonImage.sprite = status.SummonSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
