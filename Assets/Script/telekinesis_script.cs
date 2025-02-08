using UnityEngine;

public class ForceController : MonoBehaviour
{
    public float telekinesisRange = 5f;
    public LayerMask interactableLayer;
    public float telekinesisSpeed = 5f;
    public Camera playerCamera;

    private bool isTelekinesisActive = false;
    private GameObject selectedObject;
    private Rigidbody selectedObjectRb;
    private float holdDistance;

    private bool isRotating = false;
    private float rotationSpeed = 100f;
    private float rotationXSpeed = 50f;
    private float minRotationX = -45f;
    private float maxRotationX = 45f;
    private bool rotateAroundX = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleTelekinesis();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            isRotating = !isRotating;
            Debug.Log("Rotation " + (isRotating ? "activée" : "désactivée"));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotateAroundX = !rotateAroundX;
            string axis = rotateAroundX ? "X" : "Y";
            Debug.Log("Rotation autour de l'axe " + axis);
        }

        if (isTelekinesisActive && selectedObject != null)
        {
            HandleTelekinesisInput();

            MoveObjectToHoldPosition();
        }
    }

    private void ToggleTelekinesis()
    {
        if (selectedObject == null)
        {
            TrySelectObject();
        }
        else
        {
            ReleaseObject();
        }
    }

    private void TrySelectObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, telekinesisRange, interactableLayer))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Interactable"))
            {
                SelectObject(hitObject);
            }
        }
    }

    private void SelectObject(GameObject obj)
    {
        selectedObject = obj;
        selectedObjectRb = selectedObject.GetComponent<Rigidbody>();

        if (selectedObjectRb != null)
        {
            selectedObjectRb.useGravity = false;
            selectedObjectRb.linearVelocity = Vector3.zero;
            selectedObjectRb.angularVelocity = Vector3.zero;
            selectedObjectRb.linearDamping = 10;
        }
        holdDistance = Vector3.Distance(playerCamera.transform.position, selectedObject.transform.position);
        isTelekinesisActive = true;
    }

    private void ReleaseObject()
    {
        if (selectedObject != null)
        {
            if (selectedObjectRb != null)
            {
                selectedObjectRb.useGravity = true;
                selectedObjectRb.linearDamping = 0;
            }
            selectedObject = null;
            selectedObjectRb = null;
        }
        isTelekinesisActive = false;
    }

    private void HandleTelekinesisInput()
    {
        if (isRotating)
        {
            if (rotateAroundX)
            {
                if (Input.GetMouseButton(0))
                {
                    RotateObject(0, 1);
                }
                if (Input.GetMouseButton(1))
                {
                    RotateObject(0, -1);
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    RotateObject(1, 0);
                }
                if (Input.GetMouseButton(1))
                {
                    RotateObject(-1, 0);
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                MoveObjectCloser();
            }
            if (Input.GetMouseButton(1))
            {
                MoveObjectFarther();
            }
        }
    }

    private void MoveObjectToHoldPosition()
    {
        if (selectedObject != null)
        {
            Vector3 targetPosition = playerCamera.transform.position + playerCamera.transform.forward * holdDistance;
            selectedObject.transform.position = Vector3.Lerp(selectedObject.transform.position, targetPosition, Time.deltaTime * telekinesisSpeed);
        }
    }

    private void MoveObjectCloser()
    {
        holdDistance -= telekinesisSpeed * Time.deltaTime;
    }

    private void MoveObjectFarther()
    {
        holdDistance += telekinesisSpeed * Time.deltaTime;
    }

    private void RotateObject(float rotationY, float rotationX)
    {
        if (selectedObject != null)
        {

            if (!rotateAroundX)
            {
                Quaternion rotationYQuat = Quaternion.Euler(0, rotationY * rotationSpeed * Time.deltaTime, 0);
                selectedObject.transform.rotation *= rotationYQuat;
            }

            if (rotateAroundX)
            {
                Quaternion rotationXQuat = Quaternion.Euler(rotationX * rotationXSpeed * Time.deltaTime, 0, 0);
                selectedObject.transform.rotation *= rotationXQuat;
            }
        }
    }
}
