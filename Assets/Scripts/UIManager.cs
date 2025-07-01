using UnityEngine; 
using UnityEngine.UI; 
using TMPro; 

public class UIManager : MonoBehaviour 
{ 
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI winText; 
    public GameObject leftButton; 
    public GameObject rightButton; 
    public GameObject jumpButton; 

    private int score = 0; 
    private int totalCollectibles; 

    void Start() 
    { 
        winText.gameObject.SetActive(false); 
        UpdateScoreText(); 
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length; 
    } 

    public void IncreaseScore(int amount) 
    { 
        score += amount; 
        UpdateScoreText(); 

        if (score >= 10 /*totalCollectibles*/) 
        { 
            winText.gameObject.SetActive(true); 
            leftButton.SetActive(false); 
            rightButton.SetActive(false); 
            jumpButton.SetActive(false); 
        } 
    } 

    void UpdateScoreText() 
    { 
        scoreText.text = "Score: " + score; 
    } 
}

