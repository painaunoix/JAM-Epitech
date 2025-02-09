using UnityEngine;

public class CheckFuture : MonoBehaviour
{
    public Torch torch;
    public GameObject FutureBad;
    public GameObject FutureGood;
    void Start()
    {

    }

    void Update()
    {
        if (torch != null) {
            if (torch.is_Torch_Active == true) {
                FutureGood.SetActive(true);
                FutureBad.SetActive(false);
            } else {
                FutureGood.SetActive(false);
                FutureBad.SetActive(true);
            }
        }
    }
}
