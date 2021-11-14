using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public static class GlobalResource
{
    
   public static double globalGold=39900000000;
   public static double globalPeople=100000;
    
}
public enum GlobalTextAbout{
    globalPeople,globalGold
}
public class GlobalResourceManager :MonoBehaviour {
   [SerializeField]
   private List<Text> globalText = new List<Text>(); 
   float Timer=0.3f;


     void Update() {
        Timer -= Time.deltaTime;
        
        if (Timer<0){

            globalText[(int)GlobalTextAbout.globalPeople].text = ToStringg(GlobalResource.globalPeople);
           globalText[(int)GlobalTextAbout.globalGold].text = ToStringg(GlobalResource.globalGold);
        Timer = 0.3f;
       }
    }


    static string[] unitSymbol = new string[] { "", "만", "억", "조", "경", "해" };

    // long 보다 double이 최대 값이 커서 double  사용
    public static string ToStringg(double value)
    {
        if (value == 0) { return "0"; }

        int unitID = 0;

        string number = string.Format("{0:# #### #### #### #### ####}", value).TrimStart();
        string[] splits = number.Split(' ');

        StringBuilder sb = new StringBuilder();

        for (int i = splits.Length; i > 0; i--)
        {
            int digits = 0;
            if (int.TryParse(splits[i - 1], out digits))
            {
                // 앞자리가 0이 아닐때
                if (digits != 0)
                {
                    sb.Insert(0, $"{ digits}{ unitSymbol[unitID] }");
                }
            }
            else
            {
                // 마이너스나 숫자외 문자
                sb.Insert(0, $"{ splits[i - 1] }");
            }
            unitID++;
        }
        return sb.ToString();
    }





    private void Start()
    {
        
    }


}



