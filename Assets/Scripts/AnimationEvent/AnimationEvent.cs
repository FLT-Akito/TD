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
        //�U���G�t�F�N�g�̏���
    }

    void EndAttackEvent()
    {
        playerBase.AttackEnd();
        //�G�t�F�N�g����������
    }
}
