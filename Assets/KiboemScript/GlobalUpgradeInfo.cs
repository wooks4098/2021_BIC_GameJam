using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct UpgradeInfo{
    public int LV;
   public double peopleAdd;
    public double requireGold;
    public float peopleAddRate;
    public float goldAddRate;
}
public static class GlobalUpgradeInfo 
{
   public static Dictionary<string, UpgradeInfo> UpgradeList = new Dictionary<string, UpgradeInfo>();
   
    

}


