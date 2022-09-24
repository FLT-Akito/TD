using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBase : StateMachineBase<UnitBase>
{
    //private static float offsetX = 2.0f;
    // private static float offsetY = 3.5f;
    private static Dictionary<string, Vector3> direction = null;
    //private PlayerBase playerbase;
    //private bool flag;
    //private Animator animator;
    public EnemyStatus enemyStatus;

    [HideInInspector]
    public Slider hpBar;
    //private GameObject eUnit;

    [SerializeField] private float speed = 1.0f;

    [HideInInspector]
    public int currentHp;


    private void Start()
    {
        if (direction == null)
        {
            direction = new Dictionary<string, Vector3>()
            {
                ["right"] = new Vector3(1f, 0, 0),
                ["left"] = new Vector3(-1f, 0, 0),
                ["down"] = new Vector3(0, -1f, 0),
            };
        }
        //Debug.Log(EnemyGenerator.Instance.EnemyUnit.name);
        
        hpBar = EnemyGenerator.Instance.EnemyUnit.GetComponentInChildren<Slider>();
        currentHp = enemyStatus.MaxHp;
        hpBar.maxValue = (float)enemyStatus.MaxHp;
        hpBar.value = currentHp;
       
        //playerbase = GetComponent<PlayerBase>();
        //animator = GetComponent<Animator>();
        ChangeState(new UnitBase.FirstDown(this));

        //if (enemyStatus.MaxHp == 0)
        //{
        //    playerbase.isAttack += flag =>
        //    {
        //        if (flag)
        //        {
        //            animator.SetBool("flag", true);
        //            Destroy(this.gameObject, 2f);
        //        }
        //        else
        //        {
        //            animator.SetBool("flag", false);
        //        }
        //    };
        //}

    }


    private class FirstDown : StateBase<UnitBase>
    {
        public FirstDown(UnitBase _machine) : base(_machine)
        {
        }
        public override void OnUpdate()
        {

            machine.transform.Translate(direction["down"] * machine.speed * Time.deltaTime);

            if (machine.transform.position.y < 3.9f)
            {

                machine.ChangeState(new UnitBase.FirstLeft(machine));
            }

        }

    }

    private class FirstLeft : StateBase<UnitBase>
    {
        public FirstLeft(UnitBase _machine) : base(_machine)
        {
        }

        public override void OnUpdate()
        {

            machine.transform.Translate(direction["left"] * machine.speed * Time.deltaTime);

            if (machine.transform.position.x < -2.4f)
            {

                machine.ChangeState(new UnitBase.SecondDown(machine));
            }

        }
    }

    private class SecondDown : StateBase<UnitBase>
    {
        public SecondDown(UnitBase _machine) : base(_machine)
        {
        }

        public override void OnUpdate()
        {

            machine.transform.Translate(direction["down"] * machine.speed * Time.deltaTime);

            if (machine.transform.position.y < 2.2f)
            {
                machine.ChangeState(new UnitBase.FirstRight(machine));
            }

        }
    }

    private class FirstRight : StateBase<UnitBase>
    {
        public FirstRight(UnitBase _machine) : base(_machine)
        {
        }
        public override void OnUpdate()
        {

            machine.transform.Translate(direction["right"] * machine.speed * Time.deltaTime);

            if (machine.transform.position.x > 2.4f)
            {
                machine.ChangeState(new UnitBase.ThirdDown(machine));
            }
        }
    }

    private class ThirdDown : StateBase<UnitBase>
    {
        public ThirdDown(UnitBase _machine) : base(_machine)
        {
        }

        public override void OnUpdate()
        {

            machine.transform.Translate(direction["down"] * machine.speed * Time.deltaTime);

            if (machine.transform.position.y < 0.2f)
            {
                machine.ChangeState(new UnitBase.SecondLeft(machine));
            }

        }
    }

    private class SecondLeft : StateBase<UnitBase>
    {
        public SecondLeft(UnitBase _machine) : base(_machine)
        {
        }

        public override void OnUpdate()
        {

            machine.transform.Translate(direction["left"] * machine.speed * Time.deltaTime);

            if (machine.transform.position.x < -2.4f)
            {
                machine.ChangeState(new UnitBase.FourthDown(machine));
            }
        }
    }

    private class FourthDown : StateBase<UnitBase>
    {
        public FourthDown(UnitBase _machine) : base(_machine)
        {
        }

        public override void OnUpdate()
        {

            machine.transform.Translate(direction["down"] * machine.speed * Time.deltaTime);

            if (machine.transform.position.y < -1.8f)
            {
                machine.ChangeState(new UnitBase.SecondRight(machine));
            }

        }
    }

    private class SecondRight : StateBase<UnitBase>
    {
        public SecondRight(UnitBase _machine) : base(_machine)
        {
        }

        public override void OnUpdate()
        {

            machine.transform.Translate(direction["right"] * machine.speed * Time.deltaTime);

            if (machine.transform.position.x > 0f)
            {
                machine.ChangeState(new UnitBase.FifthDown(machine));
            }
        }

    }

    private class FifthDown : StateBase<UnitBase>
    {
        public FifthDown(UnitBase _machine) : base(_machine)
        {
        }

        public override void OnUpdate()
        {

            machine.transform.Translate(direction["down"] * machine.speed * Time.deltaTime);
            if (machine.transform.position.y < -3.0f)
            {
                machine.ChangeState(new UnitBase.Finish(machine));
            }
        }


    }

    private class Finish : StateBase<UnitBase>
    {
        public Finish(UnitBase _machine) : base(_machine)
        {
        }

    }
}





