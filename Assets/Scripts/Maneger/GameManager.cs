using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int currentStage = 1;
    private int coins = 0;
    private int getCoin = 1;
    private int crystals = 0;
    [SerializeField] Text waveText;
    [SerializeField] Text coinsText;
    [SerializeField] Text crystal_BagText;


    public int CurrentStage { get => currentStage;}
    // Start is called before the first frame update
    void Start()
    {
        waveText.text = string.Format("Wave{0}", currentStage);
        coinsText.text = string.Format("{0}", coins);
        crystal_BagText.text = string.Format("{0}", crystals);
    }

    public void NextWave()
    {
        currentStage++;
        waveText.text = string.Format("Wave{0}", currentStage);
    }

   public void GetCoin(int magni)
    {
        coins += getCoin * magni;
        coinsText.text = string.Format("{0}", coins);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
