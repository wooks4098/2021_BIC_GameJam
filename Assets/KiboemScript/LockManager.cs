using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class UnLockID{
    int count;
    int cutLine;


}

public class LockManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> EventButtons;
    [SerializeField]
    private List<Button> ViewButtons;

    private int[] lockID = { 0, 0, 0, 0 };
   // private bool[] buttEventLockID = {false, false, false, false, false, false, false, false, false, false, false };

    [SerializeField]
    private LevelObjectEvent LOE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CheckUnLockView();
        //MapCheck();
        CheckUnlockButtonEvent();
    }
    void CheckUnLockView()
    {
        if (GlobalUpgradeInfo.UpgradeList["U4"].LV >= 1)
            ViewButtons[0].interactable = true;
        else if (GlobalUpgradeInfo.UpgradeList["U7"].LV >= 1)
            ViewButtons[1].interactable = true;
        else if (GlobalUpgradeInfo.UpgradeList["U10"].LV >= 1)
            ViewButtons[2].interactable = true;
    }
    //�� �̺�Ʈ ���� �� ȣ��
    public void OnUpdateEventSlotLevelUp(int upGradeID)
    {
        

                lockID[upGradeID]++;
        MapCheck();
    }
    
    // � �� �̺�Ʈ �ܰ踦 �ر��� �� ���� + � �ʿ� �ش��ϴ��� üũ
    void MapCheck()
    {
        int temp;

        for(int i = 0; i< lockID.Length; i++)
        {
            if (lockID[i] == 0)
                continue;
            if ( lockID[i] % 10 != 0)
                continue;
            temp = (int)(lockID[i] / 10-1) ;
            switch (i)
            {
                case 0:

                    MapEvent(0, temp);
                    break;
                case 1:

                    MapEvent(1, temp);
                    break;
                case 2:

                    MapEvent(2, temp);
                    break;
                case 3:

                    MapEvent(3, temp);
                    break;
            }
        }

        //foreach(int i in lockID)
        //{
        //    if (i % 10 != 0)
        //        continue;
        //    temp = (int)(i / 10)-1;
        //    switch (temp)
        //    {
        //        case 0:
                     
        //            MapEvent(0, temp);
        //            break;
        //        case 1:
                    
        //            MapEvent(1, temp);
        //            break;
        //        case 2:
                    
        //            MapEvent(2, temp);
        //            break;
        //        case 3:
                    
        //            MapEvent(3, temp);
        //            break;
        //    }
        //}
    }
    //�� �̺�Ʈ �߻�
    void  MapEvent (int lockID,int level)
    {
        switch (lockID)
        {
            case 0:
                LOE.HoseLevelEvent(level);

                break;
            case 1:
                LOE.MartLevelEvent(level);
                break;
            case 2:
                LOE.StreetLevelEvent(level);
                break;
            case 3:
                LOE.CityLevelEvent(level);
                break;
        }
    }

    void CheckUnlockButtonEvent()
    {
        foreach (var info in GlobalUpgradeInfo.UpgradeList)
        {
            if (GlobalResource.globalGold > info.Value.requireGold)
            {
                EventButtons[info.Value.EventNO].SetActive(true);
                CheckUnLockView();
            }
            


           

        }
    }
}
