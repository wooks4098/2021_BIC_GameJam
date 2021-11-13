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
    public string UpgradeName;
    [SerializeField]
    private List<Text> buttonTexts;
   
   [SerializeField]
    private int LV;
    [SerializeField]
    private float peopleAdd;
     [SerializeField]
    private float requireGold;
     [SerializeField]
    private float goldAddRate;
    [SerializeField]
    private float goldLevelConstant;
    [SerializeField]
    private int EventNO;

    LockManager lockManager;
    private void Awake()
    {
        lockManager = FindObjectOfType<LockManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        thisUpgradeInfo.LV = LV;
       thisUpgradeInfo.peopleAdd = peopleAdd;
       thisUpgradeInfo.requireGold = requireGold;
       //thisUpgradeInfo.peopleAddRate = peopleAddRate;
       thisUpgradeInfo.goldAddRate = goldAddRate;
        thisUpgradeInfo.EventNO = this.EventNO;
        GlobalUpgradeInfo.UpgradeList.Add(UpgradeName, thisUpgradeInfo);
        

       buttonTexts[(int)ButtonTextAbout.LV].text = GlobalResourceManager.ToStringg(thisUpgradeInfo.LV);
        buttonTexts[(int)ButtonTextAbout.GOLD].text = GlobalResourceManager.ToStringg(thisUpgradeInfo.requireGold);
        buttonTexts[(int)ButtonTextAbout.POPULATION].text = "+" + GlobalResourceManager.ToStringg(thisUpgradeInfo.peopleAdd);

        if (EventNO != 0)
            this.gameObject.SetActive(false);
    }
    public void OnClickUpgradeButton(string UpgradeName){
        var targetUpgradeInfo= GlobalUpgradeInfo.UpgradeList[UpgradeName];
        if(GlobalResource.globalGold -targetUpgradeInfo.requireGold>=0){
            GlobalResource.globalPeople += targetUpgradeInfo.peopleAdd;
                //targetUpgradeInfo.peopleAdd;
            GlobalResource.globalGold -= targetUpgradeInfo.requireGold;
            targetUpgradeInfo.LV++;
             //targetUpgradeInfo.peopleAdd = (int)targetUpgradeInfo.peopleAddRate*targetUpgradeInfo.LV;
            targetUpgradeInfo.requireGold += Mathf.Pow(goldLevelConstant * targetUpgradeInfo.LV, targetUpgradeInfo.goldAddRate);
                //(int)targetUpgradeInfo.goldAddRate*targetUpgradeInfo.LV;
            GlobalUpgradeInfo.UpgradeList[UpgradeName] =  targetUpgradeInfo;


             buttonTexts[(int)ButtonTextAbout.LV].text = GlobalResourceManager.ToStringg(targetUpgradeInfo.LV);
             buttonTexts[(int)ButtonTextAbout.GOLD].text = GlobalResourceManager.ToStringg(targetUpgradeInfo.requireGold);
              GlobalUpgradeInfo.UpgradeCount++;
            Debug.Log("UpgradeCount:" + GlobalUpgradeInfo.UpgradeCount);
            // buttonTexts[(int)ButtonTextAbout.POPULATION].text ="+"+ targetUpgradeInfo.peopleAdd.ToString();

            lockManager.OnUpdateEventSlotLevelUp(LV);
        }
        else{
            Debug.Log("Not Enough Money");
            //targetUpgradeInfo.LV++;

            }




        
      

        
    }

    

    
    void Update()
    {
        
    }
}
