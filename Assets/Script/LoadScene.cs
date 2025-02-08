using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void loadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
