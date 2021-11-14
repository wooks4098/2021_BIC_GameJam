using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ChangeMaterial
{
    public Material materials;
    public MeshRenderer[] meshRenderers;
}

[System.Serializable]
public class LevelGroup
{
    public Image[] image;
    public ChangeMaterial[] changeMaterials;
    public GameObject[] People;

}
[System.Serializable]
public class SceneGroup
{
    public LevelGroup[] levelGroups;
}

public class LevelObjectEvent : MonoBehaviour
{
    public SceneGroup House;
    public SceneGroup Mart;
    public SceneGroup Street;
    public SceneGroup City;
    int test = -1;
    [SerializeField] GameEnd gameEnd;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            test++;
            Debug.Log(test);
            //HoseLevelEvent(test);
            //MartLevelEvent(test);
            //  StreetLevelEvent(test);
           // CityLevelEvent(test);

        }
    }

    public void CityLevelEvent(int OpenLevel)
    {
        ImageOpen(City.levelGroups[OpenLevel].image);
        MaterialChange(City.levelGroups[OpenLevel].changeMaterials, 0);
        ObjectShow(City.levelGroups[OpenLevel].People);
        if (OpenLevel == 3)
            gameEnd.End();
    }

    public void StreetLevelEvent(int OpenLevel)
    {
        ImageOpen(Street.levelGroups[OpenLevel].image);
        MaterialChange(Street.levelGroups[OpenLevel].changeMaterials, 0);
        ObjectShow(Street.levelGroups[OpenLevel].People);
    }

    void ObjectShow(GameObject[] People)
    {
        for(int i = 0; i< People.Length; i++)
        {
            People[i].SetActive(true);
        }
    }

    void MaterialChange(ChangeMaterial[] changeMaterials, int materindex)
    {
        for (int i = 0; i < changeMaterials.Length; i++)
        {
            for (int j = 0; j < changeMaterials[i].meshRenderers.Length; j++)
            {
                Material[] materials = changeMaterials[i].meshRenderers[j].materials;
                materials[materindex] = changeMaterials[i].materials;
                changeMaterials[i].meshRenderers[j].materials = materials;
            }

        }
    }
    public void MartLevelEvent(int OpenLevel)
    {
        ImageOpen(Mart.levelGroups[OpenLevel].image);
        MaterialChange(Mart.levelGroups[OpenLevel].changeMaterials,0);
    }

    #region Áý HoseLevelEvent(int OpenLevel)

    public void HoseLevelEvent(int OpenLevel)
    {
        ImageOpen(House.levelGroups[OpenLevel].image);
        if (OpenLevel == 3)
            MaterialChange(House.levelGroups[OpenLevel].changeMaterials,1);


    }


    void ImageOpen(Image[] images)
    {
        Color color;
        for (int i = 0; i < images.Length; i++)
        {
            color = images[i].color;
            color.a = 100;
            images[i].color = color;
        }
    }

    #endregion
}
