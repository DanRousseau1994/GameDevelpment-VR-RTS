using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public Text MoneyTExt;
    
   
    void Update()
    {
        MoneyTExt.text = PlacementController.PlacementControllerInstance.avaliableMoney.ToString();
    }
}