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

    [SerializeField] Image People;
    [SerializeField] Image Gold;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            StartNews();
    }
    public void StartNews()
    {
        int i = Random.Range(0, 2);
        switch(i)
        {
            case 0:
                ShowBadNews();
                break;
            case 1:
                ShowGoodNews();
                break;

        }
    }

    void ShowBadNews()
    {
        NewsBase.SetActive(true);
        news[0].Base.SetActive(true);
        int num = Random.Range(0, 8);
        news[0].Info.text = BadnewsInfo[num].info;

        int Type = Random.Range(0, 2);
        switch (Type)
        {
            default:
                break;
        }
    }
    void ShowGoodNews()
    {
        NewsBase.SetActive(true);
        news[1].Base.SetActive(true);
        int num = Random.Range(0, 8);
        news[1].Info.text = GoodnewsInfo[num].info;


    }

    public void Close()
    {
        NewsBase.SetActive(false);
        news[0].Base.SetActive(false);
        news[1].Base.SetActive(false);
    }

}
