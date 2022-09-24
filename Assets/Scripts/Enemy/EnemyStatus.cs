using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemyStatus")]
public class EnemyStatus : ScriptableObject
{
    
    [SerializeField] int maxHp;
    

    public int MaxHp { get => maxHp; }
    public int Defence { get; set; }
}
