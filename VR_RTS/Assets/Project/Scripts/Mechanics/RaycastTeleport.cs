using UnityEngine;

public class RaycastTeleport : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform rayPoint;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hitInfo,
                Mathf.Infinity, mask))
            {
                if (hitInfo.collider.tag == "Point")
                {
                    this.gameObject.transform.position = hitInfo.collider.gameObject.transform.position;
                    this.gameObject.transform.rotation = hitInfo.collider.gameObject.transform.rotation;
                }
            }
        }
    }
}