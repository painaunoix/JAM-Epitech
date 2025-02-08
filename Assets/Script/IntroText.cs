using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroText : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public Button startButton;
    public float typingSpeed = 0.05f;
    public int maxLines = 5;

    private string fullText = 
        "Tout allait bien sur l’île.\nC’était un endroit paisible, où tu apprenais la magie\navec ton maître, Arthur.\nIl t’entraînait chaque jour, te répétant que la force ne faisait pas tout, que la magie demandait réflexion et maîtrise.\n" +
        "Mais un jour, tout bascula.\n" +
        "Des envahisseurs débarquèrent sans prévenir.\nIls attaquèrent ton maître.\nTu n’as rien pu faire. Quand la fumée s’est dissipée,\nil n’était plus là.\n" +
        "Ton maître a été tué.\nTu ne peux pas rester là sans rien faire.\n" +
        "Tu dois les retrouver.\nTu dois te venger !";

    private List<string> currentLines = new List<string>();
    private string currentText = "";

    void Start()
    {
        startButton.gameObject.SetActive(false);
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            currentText += letter;

            if (letter == '\n')
            {
                currentLines.Add(currentText.Trim());
                currentText = "";

                while (currentLines.Count > maxLines)
                {
                    currentLines.RemoveAt(0);
                }
            }

            introText.text = string.Join("\n", currentLines) + "\n" + currentText;

            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(1f);
        startButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Aymeric");
    }
}
