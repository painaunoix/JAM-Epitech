using UnityEngine;

public class CountEnemies : MonoBehaviour
{
    public GameObject Mage;
    public GameObject Health;
    public void count()
    {
        // Trouver tous les GameObjects dans la scène
        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();

        // Compter ceux qui ont le nom "EnnemiWithAnim"
        int count = 0;
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.name == "EnnemiWithAnim")
            {
                count++;
            }
        }

        // Afficher le résultat
        Debug.Log("Nombre de GameObjects avec le nom 'EnnemiWithAnim' : " + count);
        if (count == 1) {
            Mage.SetActive(true);
            Health.SetActive(false);
        }
    }
}
