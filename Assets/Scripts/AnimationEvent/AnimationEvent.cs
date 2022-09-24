using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public PlayerBase playerBase;
    

    void onAttackEvent()
    {
        playerBase.Attack();
        //攻撃エフェクトの処理
    }

    void EndAttackEvent()
    {
        playerBase.AttackEnd();
        //エフェクトを消す処理
    }
}
