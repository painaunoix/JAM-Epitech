using UnityEngine;


public class PressurePlate : MonoBehaviour
{
    private int pushed = 0;
    public GameObject obj;
    public string type;
    private float downed = 0;
    private float targetHeight;

    void Start()
    {
        if (obj != null)
        {
            targetHeight = obj.GetComponent<Renderer>().bounds.size.y; // Get the object's height
        }
    }

    void MoveBarrierUp()
    {
        if (obj == null) return;
        if (targetHeight < downed) return;

        float moveStep = 5f * Time.deltaTime;
        Debug.Log(targetHeight);
        Debug.Log(downed);
        Vector3 targetPosition = obj.transform.position - new Vector3(0, targetHeight, 0);
        obj.transform.position = Vector3.Lerp(obj.transform.position, targetPosition, 1f * Time.deltaTime);
        Debug.Log(targetPosition);
        downed += moveStep;
        if (Vector3.Distance(obj.transform.position, targetPosition) < 0.01f)
        {
            obj.transform.position = targetPosition;
        }
    }
    void MoveBarrierDown()
    {
        if (obj == null) return;
        if (downed <= 0) return;

        float moveStep = 5f * Time.deltaTime;
        Debug.Log(targetHeight);
        Debug.Log(downed);
        Vector3 targetPosition = obj.transform.position + new Vector3(0, targetHeight, 0);
        obj.transform.position = Vector3.Lerp(obj.transform.position, targetPosition, 1f * Time.deltaTime);
        Debug.Log(targetPosition);
        downed -= moveStep;
        if (Vector3.Distance(obj.transform.position, targetPosition) < 0.01f)
        {
            obj.transform.position = targetPosition;
        }
    }

    void OnTriggerEnter(Collider collide)
    {
        Debug.Log("יייייי");
        if (!collide.gameObject.CompareTag("FireBall"))
        {
            pushed += 1;
        }
    }

    void OnTriggerExit(Collider collide)
    {
        Debug.Log("dsfqsdfqsdf");
        if (!collide.gameObject.CompareTag("FireBall"))
        {
            pushed -= 1;
        }
    }

    void Update()
    {
        if (pushed > 0 && type == "barrier")
        {
            MoveBarrierUp();
        }
        if (pushed <= 0 && type == "barrier")
        {
            MoveBarrierDown();
        }
    }
}
