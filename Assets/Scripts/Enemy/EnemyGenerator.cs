using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator Instance;
    public GameObject[] prfEnemys;
    public List<GameObject> enemyList = new List<GameObject>();
    public GameManager gameManager;
    public Text waveText;
    public GameObject EnemyUnit { get; set; }
    private GameObject emUnit;

    [Range(1f, 5f)]
    [Header("出現する間隔")]
    public float interval;

   
    [Header("各ステージごとの出現数")]
    public int[] maxNumOfOccurrences;

    private float time;
    private int stageCount = 0;
    private static readonly int stageMaxCount = 50;
    
    // private int numOfEnemy;

    //シングルトン
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    //public GameObject GetHpbar()
    //{
    //    if(EnemyUnit != null)
    //    {

    //    }
    //    return EnemyUnit;
    //}
    private void Start()
    {
      
        //string[] del = { "Wave" };
        //var t = waveText.text.Split(del,System.StringSplitOptions.None);
        //var i = int.Parse(t[1]);
        //Debug.Log(i);
    }

    private void Update()
    {
        if (maxNumOfOccurrences[stageCount] == 0)
        {
           
            return;
          
        }
        time += Time.deltaTime;
        if (time > interval)
        {
            time = 0;
            
            EnemyUnit = AppearEnemey(emUnit);
           
        }
    }

    private GameObject AppearEnemey(GameObject unit)
    {
        int[] enemyposi = { 1, -1 };
        int enemyposiIndex = Random.Range(0, enemyposi.Length);
        int enemyIndex = Random.Range(0, prfEnemys.Length);
         unit = Instantiate(prfEnemys[enemyIndex]);
        // go.name = $"enemy_{enemyList.Count}";
        
        enemyList.Add(unit);
        unit.transform.position = new Vector2(enemyposi[enemyposiIndex], 6f);

        maxNumOfOccurrences[stageCount]--;
        return unit;
    }


    public GameObject GetniaryEnemy(Vector3 basePosition)
    {
        GameObject ret = null;
        float distanceMin = 0;
        foreach (GameObject targetObject in enemyList)
        {
            float distance = Vector3.Distance(basePosition, targetObject.transform.position);
            if (ret == null)
            {
                ret = targetObject;
                distanceMin = distance;
            }
            else if (distance < distanceMin)
            {
                ret = targetObject;
                distanceMin = distance;
            }
        }

        return ret;
    }


    public List<GameObject> GetEnemysInRange(Vector3 point, float range)
    {
        List<GameObject> ret = new List<GameObject>();
        foreach (GameObject enemy in enemyList)
        {
            //条件を満たす場合retに加える
            if (Vector3.Distance(point, enemy.transform.position) < range)
            {
                ret.Add(enemy);
            }
        }
        return ret;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemyList.Contains(enemy))
        {
            int coinmagni = 1;
            enemyList.Remove(enemy);
            Destroy(enemy);
            gameManager.GetCoin(coinmagni);
        }
       if(enemyList.Count == 0)
        {
            //敵が全滅したら次のウェーブに移動の処理
            gameManager.NextWave();
            stageCount++;
            if (gameManager.CurrentStage == stageCount)
            {
                return;               
                //初回Waveクリアのみ魔法石を1個獲得
            }
            if (gameManager.CurrentStage > stageMaxCount)
            {
                //ステージクリアの処理を実行させる
            }

        }

    }
    
}
