using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class script1 : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public GameObject completeImage;
    public float completeImageDuration = 2f;

    public AudioSource successSound;
    public AudioSource failureSound;

    private int score = 0;
    private bool puzzleSolved = false;
    private float elapsedTime = 0f; // Ajout de la variable elapsedTime
    private int attempts = 0;
    public float totalTime = 60f; // Durée totale du jeu en secondes
    private float timeRemaining;

    public void UpdateElapsedTime(float time)
    {
        elapsedTime = time;
    }

    void Start()
    {
        timeRemaining = totalTime; // Initialiser le temps restant
        StartCoroutine(ShowCompleteImageAtStart());
        scoreText.text = "Score: " + score.ToString();
        winText.text = "";
    }

    IEnumerator ShowCompleteImageAtStart()
    {
        completeImage.SetActive(true);
        yield return new WaitForSeconds(completeImageDuration);
        completeImage.SetActive(false);
        ShufflePuzzle();
    }

    void Update()
    {
        // Mettre à jour le temps restant
        timeRemaining -= Time.deltaTime;

        // Vérifier la défaite
        if (timeRemaining <= 0f)
        {
            // Le temps est écoulé et le joueur n'a pas terminé le puzzle
            // Déclarez une défaite ici
            winText.text = "You lose! Time's up.";
            Debug.Log("Vous avez perdu! Le temps est écoulé.");
            // Ajoutez ici la logique pour gérer la défaite
            return; // Sortir de la fonction Update
        }

        // Vérifier la victoire
        if (score >= 400)
        {
            // Le joueur a terminé le puzzle avant la fin du temps imparti
            // Déclarez une victoire ici
            winText.text = "Congratulations! You've successfully formed the letter 'A'! You're a fantastic puzzler!";

            // Time evaluation
            float timeTaken = totalTime - timeRemaining;
            string timeEvaluation = "Time taken: " + timeTaken.ToString("f2") + " seconds";
            winText.text += "\n" + timeEvaluation;

            // Attempts evaluation
            string attemptsEvaluation = "Attempts: " + attempts.ToString();
            winText.text += "\n" + attemptsEvaluation;

            Debug.Log("Félicitations! Vous avez terminé le puzzle avant la fin du temps imparti.");
            // Ajoutez ici la logique pour gérer la victoire
            return; // Sortir de la fonction Update
        }
    }

    void ShufflePuzzle()
    {
        for (int i = puzzlePieces.Length - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            GameObject temp = puzzlePieces[i];
            puzzlePieces[i] = puzzlePieces[j];
            puzzlePieces[j] = temp;
        }

        foreach (GameObject pieceObject in puzzlePieces)
        {
            pieceObject.transform.position = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void OnButtonClick()
    {
        CheckPuzzleCompletion();
    }

    public void OnPieceDrag()
    {
        attempts++;
    }

    void CheckPuzzleCompletion()
    {
        if (score >= 400)
        {
            // La victoire est déjà gérée dans Update()
            // Les commentaires de victoire sont ajoutés à winText dans Update()
        }
        else if (timeRemaining <= 0f)
        {
            // Le temps est écoulé et le joueur n'a pas terminé le puzzle
            // Déclarez une défaite ici
            winText.text = "You lose! Time's up.";
            Debug.Log("Vous avez perdu! Le temps est écoulé.");
            // Ajoutez ici la logique pour gérer la défaite
        }
        else if (score >= 300 && score < 400)
        {
            winText.text = "You're a puzzle master! You're very close to forming the letter 'A'.";
        }
        else if (score >= 200 && score < 300)
        {
            winText.text = "Super job! Almost there! Keep matching the letters to complete the 'A'.";
        }
        else if (score >= 100 && score < 200)
        {
            winText.text = "Excellent progress! You're on the right track to forming the letter 'A'.";
        }
        else if (score < 100)
        {
            winText.text = "You're doing great! Keep exploring and matching the letters.";
        }
    }

    public void RestartGame()
    {
        // Réinitialisez les variables de jeu
        score = 0;
        puzzleSolved = false;
        elapsedTime = 0f;
        attempts = 0;
        timeRemaining = totalTime; // Réinitialiser le temps restant

        // Réinitialisez l'interface utilisateur
        scoreText.text = "Score: " + score.ToString();
        winText.text = "";

        // Mélangez le puzzle à nouveau
        ShufflePuzzle();
    }

    public void OnRestartButtonClick()
    {
        RestartGame();
    }
}
