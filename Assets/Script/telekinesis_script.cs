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
    private float holdDistance; // Distance actuelle de l'objet par rapport au joueur

    private bool isRotating = false; // Indique si la rotation est activée
    private float rotationSpeed = 100f; // Vitesse de rotation
    private float rotationXSpeed = 50f; // Vitesse de la rotation sur l'axe X
    private float minRotationX = -45f; // Limite inférieure de rotation sur l'axe X
    private float maxRotationX = 45f;  // Limite supérieure de rotation sur l'axe X
    private bool rotateAroundX = false; // Indicateur pour savoir si on tourne sur l'axe X ou Y

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Prendre ou relâcher l'objet
        {
            ToggleTelekinesis();
        }

        if (Input.GetKeyDown(KeyCode.R)) // Activer ou désactiver la rotation de l'objet
        {
            isRotating = !isRotating; // Alterne l'état de la rotation
            Debug.Log("Rotation " + (isRotating ? "activée" : "désactivée"));
        }

        if (Input.GetKeyDown(KeyCode.Q)) // Changer l'axe de rotation (X ou Y)
        {
            rotateAroundX = !rotateAroundX;
            string axis = rotateAroundX ? "X" : "Y";
            Debug.Log("Rotation autour de l'axe " + axis);
        }

        if (isTelekinesisActive && selectedObject != null)
        {
            HandleTelekinesisInput(); // Entrées pour déplacer ou tourner l'objet

            MoveObjectToHoldPosition(); // Maintient l'objet en face du joueur
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

        holdDistance = Vector3.Distance(playerCamera.transform.position, selectedObject.transform.position); // Définit la distance initiale
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
        if (isRotating) // Si la rotation est activée
        {
            if (rotateAroundX) // Si on tourne autour de l'axe X
            {
                // Rotation autour de l'axe X
                if (Input.GetMouseButton(0)) // Clic gauche -> Rotation autour de l'axe X (haut/bas)
                {
                    RotateObject(0, 1); // Rotation dans le sens haut-bas
                }
                if (Input.GetMouseButton(1)) // Clic droit -> Rotation autour de l'axe X (haut/bas)
                {
                    RotateObject(0, -1); // Rotation dans le sens bas-haut
                }
            }
            else // Si on tourne autour de l'axe Y
            {
                // Rotation autour de l'axe Y
                if (Input.GetMouseButton(0)) // Clic gauche -> Rotation autour de l'axe Y (gauche/droite)
                {
                    RotateObject(1, 0); // Rotation dans le sens horaire
                }
                if (Input.GetMouseButton(1)) // Clic droit -> Rotation autour de l'axe Y (gauche/droite)
                {
                    RotateObject(-1, 0); // Rotation dans le sens antihoraire
                }
            }
        }
        else // Si la rotation n'est pas activée, on déplace l'objet
        {
            if (Input.GetMouseButton(0)) // Clic gauche -> Rapproche l'objet
            {
                MoveObjectCloser();
            }
            if (Input.GetMouseButton(1)) // Clic droit -> Éloigne l'objet
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
            // Rotation autour de l'axe Y (gauche/droite)
            if (!rotateAroundX)
            {
                // Appliquer la rotation autour de l'axe Y (gauche/droite)
                Quaternion rotationYQuat = Quaternion.Euler(0, rotationY * rotationSpeed * Time.deltaTime, 0);
                selectedObject.transform.rotation *= rotationYQuat; // Appliquer la rotation à l'objet
            }

            // Rotation autour de l'axe X (haut/bas)
            if (rotateAroundX)
            {
                // Rotation autour de l'axe X (haut/bas) en utilisant un quaternion
                Quaternion rotationXQuat = Quaternion.Euler(rotationX * rotationXSpeed * Time.deltaTime, 0, 0);
                selectedObject.transform.rotation *= rotationXQuat; // Appliquer la rotation à l'objet
            }
        }
    }
}
