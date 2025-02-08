using UnityEngine;

public class CheckFuture : MonoBehaviour
{
    public Torch torch;
    public GameObject FutureBad;
    public GameObject FutureGood;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
