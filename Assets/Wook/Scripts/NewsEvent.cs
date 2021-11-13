using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum NewsType
{
    Bad = 0,
    Good,
}
public enum ChangeType
{
    People = 0,
    Gold,
}
[System.Serializable]
public class News
{
    public GameObject Base;
    public NewsType newsType;
    public Image Newsicon;
    public Text Info;
    public Image EventIcon;
    public Text updown;


}

[System.Serializable]
public class NewsInfo
{
    public NewsType newsType;
    public string info;

}

public class NewsEvent : MonoBehaviour
{
    [SerializeField] News[] news;
    [SerializeField] NewsInfo[] BadnewsInfo;
    [SerializeField] NewsInfo[] GoodnewsInfo;

    [SerializeField] GameObject NewsBase;

    [SerializeField] Sprite People;
    [SerializeField] Sprite Gold;





    public void StartNews(int level, int Count)
    {
        int i = Random.Range(0, 3);
        switch(i)
        {
            case 0:
            case 1:
                ShowBadNews(level, Count) ;
                break;
            case 2:
                ShowGoodNews(level, Count);
                break;

        }
    }

    void ShowBadNews(int level, int Count)
    {
        SoundManager.instance.SoundEffect("BadNews");
        NewsBase.SetActive(true);
        news[0].Base.SetActive(true);
        int num = level + (Count / 8 - 1);
        news[0].Info.text = BadnewsInfo[num].info;

        int Type = Random.Range(0, 2);
        int temp;
        switch (Type)
        {
            case 0: // µ∑-
                news[0].EventIcon.sprite = Gold;
                double gold = GlobalResource.globalGold;
                gold =(gold * 0.3 + gold * 0.1 * num);
                Debug.Log(gold);
                GlobalResource.globalGold -= gold;
                temp = (int)gold;
                news[0].updown.text = "-" + temp.ToString();
                break;
            case 1: // ¿Œ±∏-
                news[0].EventIcon.sprite = People;
                int people = (int)GlobalResource.globalPeople;
                people = (int)(people * 0.08 + people * 0.17 * num);
                GlobalResource.globalPeople -= people;
                temp = (int)people;
                news[0].updown.text = "-" + temp.ToString();
                break;
        }
    }
   public  void ShowGoodNews(int level, int Count)
    {
        SoundManager.instance.SoundEffect("GoodNews");
        NewsBase.SetActive(true);
        news[1].Base.SetActive(true);
        int num = level + (Count / 8 - 1);
        news[1].Info.text = GoodnewsInfo[num].info;

        int Type = Random.Range(0, 2);
         int temp;
        switch (Type)
        {
            case 0: // µ∑+
                news[1].EventIcon.sprite = Gold;
                int gold = (int)GlobalResource.globalGold;
                gold = (int)(gold * 0.3 + gold * 0.1 * num);
                GlobalResource.globalGold += gold;
                temp = (int)gold;
                news[1].updown.text = "+" + temp.ToString();

                break;
            case 1: // ¿Œ±∏+
                news[1].EventIcon.sprite = People;
                int people = (int)GlobalResource.globalPeople;
                people = (int)(people * 0.04 + people * 0.14 * num);
                temp = (int)people;
                GlobalResource.globalPeople += people;
                news[1].updown.text = "+" + temp.ToString();

                break;
        }
    }

    public void Close()
    {
        NewsBase.SetActive(false);
        news[0].Base.SetActive(false);
        news[1].Base.SetActive(false);
        SoundManager.instance.SoundEffect("Buy");
    }

}
