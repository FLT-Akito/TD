using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamegeTest : MonoBehaviour
{
    //public int maxHp;
    public EnemyStatus enemyStatus;
    private GameObject enemy;
    private Slider hpSlider;
    private int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("attack_12");
        hpSlider = enemy.GetComponentInChildren<Slider>();
        currentHp = enemyStatus.MaxHp;
        hpSlider.value = (float)enemyStatus.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentHp -= 30;
            hpSlider.value = (float)currentHp / (float)enemyStatus.MaxHp;

            if(currentHp <= 0)
            {
                Debug.Log("Ž€–S");
            }
        }
    }
}
