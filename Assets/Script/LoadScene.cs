using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
