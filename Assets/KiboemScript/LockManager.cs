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
    [SerializeField] CameraShake[] cameraShake;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] NewsEvent NewsEvent;

    [SerializeField] Animator aniParticle;
    [SerializeField] Transform transParticle;

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
        if (GlobalUpgradeInfo.UpgradeList["U4"].LV >= 1 && ViewButtons[0].interactable != true)
        {
            SoundManager.instance.SoundEffect("Unlock");
            ViewButtons[0].interactable = true;
            transParticle.position = ViewButtons[0].transform.position;
            aniParticle.SetTrigger("Show");
        }
        if (GlobalUpgradeInfo.UpgradeList["U7"].LV >= 1 && ViewButtons[1].interactable != true)
        {
            ViewButtons[1].interactable = true;
            SoundManager.instance.SoundEffect("Unlock");
            transParticle.position = ViewButtons[1].transform.position;
            aniParticle.SetTrigger("Show");
        }
        if (GlobalUpgradeInfo.UpgradeList["U10"].LV >= 1 && ViewButtons[2].interactable != true)
        {
            ViewButtons[2].interactable = true;
            SoundManager.instance.SoundEffect("Unlock");
            transParticle.position = ViewButtons[2].transform.position;
            aniParticle.SetTrigger("Show");

        }
           
    }


    //각 이벤트 업글 시 호출
    public void OnUpdateEventSlotLevelUp(int upGradeID)
    {
        int num = upGradeID;
        switch (num)
        {
            case 0:
            case 1:
            case 2:
                num = 0;
                break;
            case 3:
            case 4:
            case 5:
                num = 1;
                break;
            case 6:
            case 7:
            case 8:
                num = 2;
                break;
            case 9:
            case 10:
                num = 3;
                break;
        }
        

        lockID[num]++;
        SoundManager.instance.SoundEffect("Buy");
        ShowNews(num,lockID[num]);
        MapCheck(num);
    }
    void ShowNews(int level, int Count)
    {
        if(Count == 15 || Count == 30)
        {
            NewsEvent.ShowGoodNews(level, Count);
        }
    }
    // 어떤 맵 이벤트 단계를 해금할 지 결정 + 어떤 맵에 해당하는지 체크
    void MapCheck(int num)
    {
        int temp;

        if (lockID[num] == 0)
            return;
        if (lockID[num] % 10 != 0)
            return;
        temp = (int)(lockID[num] / 10 - 1);
        SoundManager.instance.SoundEffect("progress");

        switch (num)
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
    //맵 이벤트 발생
    void  MapEvent (int lockID,int level)
    {
        switch (lockID)
        {
            case 0:
                cameraManager.ChangeCamera(0);
                LOE.HoseLevelEvent(level);
                StartCoroutine(cameraShake[0].Shake(0.2f, 0.2f));
                
                break;
            case 1:
                cameraManager.ChangeCamera(1);
                LOE.MartLevelEvent(level);
                StartCoroutine(cameraShake[1].Shake(0.3f, 0.2f));
                break;
            case 2:
                cameraManager.ChangeCamera(2);
                LOE.StreetLevelEvent(level);
                StartCoroutine(cameraShake[2].Shake(0.5f, 0.2f));
                break;
            case 3:
                cameraManager.ChangeCamera(3);
                LOE.CityLevelEvent(level);
                StartCoroutine(cameraShake[3].Shake(0.7f, 0.2f)); 
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
