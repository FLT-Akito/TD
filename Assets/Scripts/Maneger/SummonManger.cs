using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SummonManger 
{
    private List<int> summonReceiveNanber = new List<int>();

    public bool AddIndexNumber(int index)
    {
        bool ret = true;

        if (!summonReceiveNanber.Contains(index))
        {
            summonReceiveNanber.Add(index);
            ret = true;
        }
        else
        {
            ret = false;
        }
            
       
        return ret;
        
    }

  
}
