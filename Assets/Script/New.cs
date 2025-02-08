using UnityEngine;
using UnityEngine.SceneManagement;

public class New : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Intro");
    }
}
