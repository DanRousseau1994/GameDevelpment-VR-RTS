using UnityEngine;

public class Resourcesources : MonoBehaviour
{
    [SerializeField]private int ResourceAvaliable;

    public static Resourcesources avaliableResources;

    private void Awake()
    {
        if(avaliableResources == null)
        {
            avaliableResources = this;
        }
    }

    public bool UseResources(int amountToUse)
    {
        if (amountToUse > ResourceAvaliable)
        {
            ResourceAvaliable -= amountToUse;
            return false;
        }
        else
            return true;
    }

    public void AddResources(int amountToAdd)
    {
        ResourceAvaliable += amountToAdd;
    }

    private void Update()
    {
        ResourceAvaliable += 1;
    }
}
