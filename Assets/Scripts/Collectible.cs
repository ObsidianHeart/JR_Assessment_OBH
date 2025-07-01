using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            UIManager uiManager = Object.FindFirstObjectByType<UIManager>();
            if (uiManager != null)
            {
                uiManager.IncreaseScore(scoreValue);
            }
            Destroy(gameObject);
        }
    }
}