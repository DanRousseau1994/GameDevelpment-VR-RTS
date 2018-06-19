using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject StandardTurret;
    public GameObject TurretTwo;
    public GameObject TurretThree;

    public int Cash;

    public PlacementController placement;

    public void SelectPrefab1()
    {
        placement.placeableObjectPrefab = StandardTurret;
        placement.CashCost = 200;
    }
    
    public void SelectPrefab2()
    {
        placement.placeableObjectPrefab = TurretTwo;
        placement.CashCost = 250;
    }
    
    public void SelectPrefab3()
    {
        placement.placeableObjectPrefab = TurretThree;
        placement.CashCost = 300;
    }
}
