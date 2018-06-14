using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField] private GameObject placeableObjectPrefab;

    private GameObject currentPlaceableObject;

    private float mouseWheelRotation;

    public Transform rayPoint;
    [SerializeField] private LayerMask _LayerMask;
    [SerializeField] private Grid grid;

    private void Update()
    {
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
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
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
            currentPlaceableObject.transform.position = grid.GetNearestPointOnGrid(hitInfo.point);
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
        if (Resourcesources.avaliableResources.UseResources(300) == false)
            return;

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            currentPlaceableObject = null;  
        }
    }
}