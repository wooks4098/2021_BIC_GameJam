using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cam
{
    House = 0,
    Mart,
    Street,
    City,
}

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject HouseCamera;
    [SerializeField] GameObject MartCamera;
    [SerializeField] GameObject StreetCamera;
    [SerializeField] GameObject CityCamera;

    GameObject OldCamera;

    private void Start()
    {
        OldCamera = HouseCamera;
    }

    public void ChangeCamera(Cam _cam)
    {
        if (OldCamera != null)
            OldCamera.SetActive(false);

        switch(_cam)
        {
            case Cam.House:
                HouseCamera.SetActive(true);
                OldCamera = HouseCamera;
                break;
            case Cam.Mart:
                MartCamera.SetActive(true);
                OldCamera = MartCamera;
                break;
            case Cam.Street:
                StreetCamera.SetActive(true);
                OldCamera = StreetCamera;
                break;
            case Cam.City:
                CityCamera.SetActive(true);
                OldCamera = CityCamera;
                break;
        }
    }

}
