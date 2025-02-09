using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OutroText : MonoBehaviour
{
    public TextMeshProUGUI outroText;
    public Button startButton;
    public float typingSpeed = 0.05f;
    public int maxLines = 5;

    private string fullText = 
        "Le combat s’achève. Tu es prêt à frapper une dernière fois…\n" +
        "Mais tout disparaît.\n" +
        "Les flammes, l’ennemi, la colère… plus rien n’existe.\nDevant toi, ton maître, vivant. Il te regarde avec un sourire.\n" +
        "«Tu as bien réagi, mais as-tu compris pourquoi ?»\n" +
        "Peu à peu, tout s’éclaire. Il n’y avait jamais eu d’envahisseurs.\nC’était un test, une illusion créée par ton maître.\n" +
        "Il voulait voir si tu étais digne de lui succéder.\n" +
        "Tu inspires profondément.\n" +
        "Tu n’es plus un simple apprenti.\n\n" +
        "Tu es prêt !";

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

            outroText.text = string.Join("\n", currentLines) + "\n" + currentText;

            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(1f);
        startButton.gameObject.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
