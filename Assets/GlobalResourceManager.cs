using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public static class GlobalResource
{
   public static float globalGold=1000;
   public static float globalPeople=0;
    
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
         Debug.Log("Counting");
           globalText[(int)GlobalTextAbout.globalPeople].text = GlobalResource.globalPeople.ToString();
           globalText[(int)GlobalTextAbout.globalGold].text = GlobalResource.globalGold.ToString();
        Timer = 0.3f;
       }
    }

    
    string NumberTranslate(float translateTargetNumber)
    {
        string returnNum="";
        if (translateTargetNumber == 0)
        {
            return "0";
        }
        float tempNumber = translateTargetNumber;
        int digit = 1;
       
        while (tempNumber/10 !=0)
        {
            tempNumber = tempNumber / 10;
            digit++;
        }
       
        if (digit > 3 && digit <= 6)
        returnNum += translateTargetNumber/1000 + "."+ translateTargetNumber%1000+"K";
        else if(digit>=7)
        returnNum += translateTargetNumber / 1000000 + "." + translateTargetNumber%1000000 + "M";

        return returnNum;
    }
    
    

    

    private void Start()
    {
        Debug.Log(NumberTranslate(123456));
    }


}



