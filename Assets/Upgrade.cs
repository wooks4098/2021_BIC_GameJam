using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonTextAbout{
    LV,GOLD,POPULATION
}
public class Upgrade : MonoBehaviour
{
    UpgradeInfo thisUpgradeInfo = new UpgradeInfo();
    [SerializeField]
    private string UpgradeName;
    [SerializeField]
    private List<Text> buttonTexts;
   
   [SerializeField]
    private int LV;
    [SerializeField]
    private int peopleAdd;
     [SerializeField]
    private int requireGold;
     [SerializeField]
    private float peopleAddRate;
     [SerializeField]
    private float goldAddRate;
    [SerializeField]
    private float goldLevelConstant;

    // Start is called before the first frame update
    void Start()
    {
        thisUpgradeInfo.LV = LV;
       thisUpgradeInfo.peopleAdd = peopleAdd;
       thisUpgradeInfo.requireGold = requireGold;
       thisUpgradeInfo.peopleAddRate = peopleAddRate;
       thisUpgradeInfo.goldAddRate = goldAddRate;
         GlobalUpgradeInfo.UpgradeList.Add(UpgradeName, thisUpgradeInfo);
    }
    public void OnClickUpgradeButton(string UpgradeName){
        var targetUpgradeInfo= GlobalUpgradeInfo.UpgradeList[UpgradeName];
        if(GlobalResource.globalGold -targetUpgradeInfo.requireGold>=0){
            GlobalResource.globalPeople += 10;
                //targetUpgradeInfo.peopleAdd;
            GlobalResource.globalGold -= targetUpgradeInfo.requireGold;
            targetUpgradeInfo.LV++;
             targetUpgradeInfo.peopleAdd = (int)targetUpgradeInfo.peopleAddRate*targetUpgradeInfo.LV;
            targetUpgradeInfo.requireGold += Mathf.Pow(goldLevelConstant * targetUpgradeInfo.LV, targetUpgradeInfo.goldAddRate);
                //(int)targetUpgradeInfo.goldAddRate*targetUpgradeInfo.LV;
            GlobalUpgradeInfo.UpgradeList[UpgradeName] =  targetUpgradeInfo;


             buttonTexts[(int)ButtonTextAbout.LV].text = targetUpgradeInfo.LV.ToString();
             buttonTexts[(int)ButtonTextAbout.GOLD].text = ((int)(targetUpgradeInfo.requireGold)).ToString();
             buttonTexts[(int)ButtonTextAbout.POPULATION].text = targetUpgradeInfo.peopleAdd.ToString();
        }
        else{
            Debug.Log("Not Enough Money");
            targetUpgradeInfo.LV++;
            }




        
      

        
    }

    

    
    void Update()
    {
        
    }
}
