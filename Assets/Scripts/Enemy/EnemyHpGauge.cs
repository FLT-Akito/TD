using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpGauge : MonoBehaviour
{
    public EnemyStatus enemyStatus;
    public Slider hpBar;
    private int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = enemyStatus.MaxHp;
        hpBar.value = (float)enemyStatus.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
