using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerBase : MonoBehaviour
{

    [Range(1f, 5f)]
    [Header("攻撃する間隔")]
    public float atkInterval;

    [Range(0f, 3f)]
    [Header("攻撃範囲")]
    public float renge;

    public PlayerStatus playerStatus;
 
    [SerializeField] private Animator animator;
  
    public float Timer { get; set; }
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector2 prevPosi;
   // public static bool isInhale;
    public bool isAttcking;
    private Vector3 lastPosition;
    private float movementSpeed = 15f;
    private System.Nullable<Vector3> moveTarget;
    private bool isDrogging;
    

    // Start is called before the first frame update
    void Start()
    {
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
       
       
    }

    public void SetMoveTarget(Vector3 pos)
    {
        moveTarget = pos;
        gameObject.layer = Layer.Dragging;
    }
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
       
        if (Timer > atkInterval && isAttcking == false)
        {
            //Debug.Log($"Timer:{Timer},isAtk{isAttcking}");
            GameObject enemy = EnemyGenerator.Instance.GetniaryEnemy(transform.position);
            if (enemy != null)
            {
                AtkRange(enemy);
            }
        }

        //OnClick();
    }

    private void AtkRange(GameObject enemy)
    {

        //Vector2 p1 = this.transform.position;
        //Vector2 p2 = enemy.transform.position;
        //Vector2 dig = p1 - p2;
        float distance = Vector2.Distance(transform.position, enemy.transform.position);
        if (distance < renge)
        {
            isAttcking = true;
            animator.SetTrigger("Attack");
            //Attack();

        }

    }

    public virtual void Attack()
    {
        //Debug.Log("Attack");
        Timer = 0;  
        List<GameObject> enemys = EnemyGenerator.Instance.GetEnemysInRange(this.transform.position, renge);
        foreach (GameObject enemy in enemys)
        {
            UnitBase unit = enemy.GetComponent<UnitBase>();
            unit.currentHp -= playerStatus.Attack;
            unit.hpBar.value = (float)unit.currentHp;
            //Debug.Log($"currentHp:{unit.currentHp},psAtk:{playerStatus.Attack},maxHP:{unit.enemyStatus.MaxHp}");
            //Debug.Log(enemy.name);
            if (unit.currentHp <= 0)
            {
                EnemyGenerator.Instance.RemoveEnemy(enemy);
            }

        }

    }

    public void AttackEnd()
    {
        isAttcking = false;
    }
   

    //クリックしたら指定した座標にランダムに配置
    //private void OnClick()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        float[] xposi = { -1.5f, 0, 1.5f };
    //        float[] yposi = { 2.7f, 0, -2.7f };
    //        int xposiIndex = Random.Range(0, 3);
    //        int yposiIndex = Random.Range(0, 3);
    //        transform.position = new Vector2(xposi[xposiIndex], yposi[yposiIndex]);
    //    }
    //}

    //ドラッグアンドドロップでPlayerの位置を配置
    private void OnMouseDrag()
    {
        //Debug.Log("OnMouseDrag");
        //screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        

        //float screenX = Input.mousePosition.x;
        //float screenY = Input.mousePosition.y;
        //float screenZ = screenPoint.z;

        //Vector3 currentScreenPoint = new Vector3(screenX, screenY, screenZ);
        //Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
        //transform.position = currentPosition;
        //Debug.Log(currentScreenPoint);
        //Debug.Log(currentPosition);

        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        currentPosition.z = 0f;
        transform.position = currentPosition;
    }

    private void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        prevPosi = transform.position;
        gameObject.layer = Layer.Dragging;
        isDrogging = true;
        lastPosition = transform.position;
       // moveTarget = lastPosition;
       // Debug.Log("OnmuseDown");
    }

    private void OnMouseUp()
    {
         //transform.position = prevPosi;
        //Debug.Log("OnMouseUp");
        //isInhale = true;
        isDrogging = false;
        gameObject.layer = Layer.Default;
        //if(moveTarget.HasValue == false)
        //{
        //    moveTarget = lastPosition;
        //}
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DropArea droparea = collision.GetComponent<DropArea>();
        if(droparea != null)
        {
            moveTarget = droparea.transform.position;
        }
    }
    protected virtual void Init() { }

    private void FixedUpdate()
    {
        if(moveTarget.HasValue)
        {
            if(isDrogging)
            {
                //moveTarget = null;
                return;
            }
            if(transform.position == moveTarget)
            {
                gameObject.layer = Layer.Default;
                moveTarget = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, moveTarget.Value, movementSpeed * Time.deltaTime);

            }
        }
        //else if(isDrogging == false)
        //{

        //}
    }
}
