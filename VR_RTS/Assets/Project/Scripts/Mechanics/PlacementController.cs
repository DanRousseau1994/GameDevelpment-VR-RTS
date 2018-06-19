using Project.Scripts;
using UnityEngine;
using VRTK;

public class PlacementController : MonoBehaviour
{
    public GameObject placeableObjectPrefab;
    public int CashCost;

    public int avaliableMoney = 400;

    private GameObject currentPlaceableObject;

    private float mouseWheelRotation;

    public Transform rayPoint;
    [SerializeField] private LayerMask _LayerMask;
    [SerializeField] private Grid grid;
    public static PlacementController PlacementControllerInstance;
    
    
    private float cooldown = 0;
    
    
    private VRTK_ControllerEvents controllerEvents;

    private void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        
        if (PlacementControllerInstance == null)
        {
            PlacementControllerInstance = this;
        }
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        HandleNewObjectHotkey();

        if (currentPlaceableObject != null)
        {
            MoveCurrentObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    private void HandleNewObjectHotkey()
    {
        if (controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.ButtonOnePress) && cooldown < 0)
        {
            cooldown = 0.5f;
            if (currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(placeableObjectPrefab);
            }
        }
    }

    private void MoveCurrentObjectToMouse()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity, _LayerMask))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            currentPlaceableObject.transform.position = hitInfo.collider.transform.position;
        }
    }

    private void RotateFromMouseWheel()
    {
        Debug.Log(Input.mouseScrollDelta);
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void ReleaseIfClicked()
    {
        if (controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.TriggerPress) && cooldown < 0 && avaliableMoney >= CashCost)
        {
            cooldown = 0.5f;
            avaliableMoney -= CashCost;
            if (CashCost <= 0)
            {
                CashCost = 0;
            }
            currentPlaceableObject = null;  
        }
    }
}