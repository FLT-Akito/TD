using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Controller_SymbolsRunes : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite[] Style1_C1;
    public Sprite[] Style1_C2;
    public Sprite[] Style1_C3;
    public Sprite[] Style1_S1;
    public Sprite[] Style1_S2;
    public Sprite[] Style1_S3;
    public Sprite[] Style2_C;
    public Sprite[] Style3_S1;
    public Sprite[] Style3_S2;
    public Sprite[] Style3_S3;
    [Header("UI Objects")]
    public GameObject SymbolPanel;
    public GameObject RunePanel;
    public GameObject UI_Text;

    private int currentPage = 0;
    private Sprite[] currentSprite;
    void Start()
    {

    }

    public void ButtonHandler(){
        GameObject buttonobject = EventSystem.current.currentSelectedGameObject;
        string buttonname = buttonobject.name;
        switch (buttonname){
            case "NextButton":
            currentPage += 1;
            if (currentPage>9) currentPage = 0;
            break;
            case "BackButton":
            currentPage -= 1;
            if (currentPage<0) currentPage = 9;
            break;
            default:
            break;
        }
        RefreshUI();
    }

    
    void RefreshUI(){
        switch (currentPage){
            case 0:
            currentSprite = Style1_C1;
            break;
            case 1:
            currentSprite = Style1_C2;
            break;
            case 2:
            currentSprite = Style1_C3;
            break;
            case 3:
            currentSprite = Style1_S1;
            break;
            case 4:
            currentSprite = Style1_S2;
            break;
            case 5:
            currentSprite = Style1_S3;
            break;
            case 6:
            currentSprite = Style2_C;
            break;
            case 7:
            currentSprite = Style3_S1;
            break;
            case 8:
            currentSprite = Style3_S2;
            break;
            case 9:
            currentSprite = Style3_S3;
            break;
            default:
            break;
        }

        for (int i=0;i<99;i++){
            if (i<75){
                SymbolPanel.transform.GetChild(i).GetComponent<Image>().sprite = currentSprite[i];
            }else{
                RunePanel.transform.GetChild(i-75).GetComponent<Image>().sprite = currentSprite[i];
            }
        }
        UI_Text.GetComponent<Text>().text = "Page " + (currentPage+1) + "/10";
    }
}

