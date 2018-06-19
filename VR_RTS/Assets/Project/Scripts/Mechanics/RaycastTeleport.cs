using UnityEngine;
using VRTK;

public class RaycastTeleport : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform rayPoint;

    [SerializeField] private GameObject ObjectToPort;

    private VRTK_ControllerEvents controllerEvents;

    private float cooldown = 0;

    private void Awake()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        
        if (controllerEvents.IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.TriggerPress) && cooldown < 0)
        {
            cooldown = 0.5f;
            RaycastHere();
        }
    }

    private void RaycastHere()
    {
        RaycastHit hitInfo;


        if (Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hitInfo,
            Mathf.Infinity, mask))
        {
            if (hitInfo.collider.CompareTag("Point"))
            {
                ObjectToPort.transform.position = hitInfo.collider.gameObject.transform.position;
                ObjectToPort.transform.rotation = hitInfo.collider.gameObject.transform.rotation;
            }
        }
    }
}