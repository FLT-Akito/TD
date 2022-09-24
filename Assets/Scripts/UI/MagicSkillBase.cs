using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicSkillBase : MonoBehaviour
{
    private float time;
    public Text magicCoolTimeText;
    private int count;
    private char[] separator = { 's' };
    private bool coolTime;
  
    private void Start()
    {
       
        //Debug.Log(count);
    }

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            
            MagicIconPush();
            string[] split = magicCoolTimeText.text.Split(separator);
            time = float.Parse(split[0]);
            coolTime = true;   
        }

        if(coolTime)
        {
            time -= Time.deltaTime;
            count = (int)time;
            count.ToString();
            //Debug.Log(count);
            //magicCoolTimeText.text = string.Join(count, "s");
        }
       
        
        if (count <= 0)
        {
            UIController.Instance.fireMagicIcon.SetActive(false);
            coolTime = false;
        }
    }

    //MagicIconPush
    public void MagicIconPush()
    {
        UIController.Instance.fireMagicIcon.SetActive(true);      
        //魔法攻撃のインスタンス化
        MagicImposition();
        count -= (int)Time.deltaTime;
    }

    protected virtual void MagicImposition() { }
}
