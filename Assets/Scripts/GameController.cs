using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour
{
    [SerializeField] List<AudioClip> _audioClips;
     [SerializeField] private AudioClip bipClip; 
    public char Letter = 'a'; // Start with 'a' since it's the first vowel in the set
    int _correctAnswers = 5;
    int _correctClicks;
    AudioSource _audioSource;
    public static GameController Instance{get; private set;}

     void Awake(){
        Instance=this;
        _audioSource=GetComponent<AudioSource>();
     }

     void OnEnable()
    {
        GenerateBoard();
        UpdateDisplayLetter();
    }

    void GenerateBoard()
    {
        var clickables = FindObjectsOfType<ClickableLetter>();
        int count = clickables.Length;
        List<char> charsList = new List<char>();

        for (int i = 0; i < _correctAnswers; i++)
        {
            charsList.Add(Letter);
        }

        for (int i = _correctAnswers; i < count; i++)
        {
            var chosenLetter = ChooseInvalidRandomChar();
            charsList.Add(chosenLetter);
        }

        ShuffleList(charsList);

        for (int i = 0; i < count; i++)
        {
            clickables[i].SetLetter(charsList[i]);
        }
        // Assuming you have a reference to your CounterText object, replace `counterText` with your reference
    CounterText counterText = FindObjectOfType<CounterText>();
    
    if (counterText != null)
    {
        counterText.SetRemaining(_correctAnswers - _correctClicks);
    }
    else
    {
        Debug.LogError("CounterText object not found in the scene.");
    }
    
    }

    private char ChooseInvalidRandomChar()
    {
        char[] vowels = { 'ǝ', 'ᴉ', 'n', 'a', 'e', 'i', 'o', 'u','y'};
        int randomIndex = UnityEngine.Random.Range(0, vowels.Length);
        var randomChar = vowels[randomIndex];

        while (randomChar == Letter)
        {
            randomIndex = UnityEngine.Random.Range(0, vowels.Length);
            randomChar = vowels[randomIndex];
        }
        return randomChar;
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    internal void HandleCorrectLetterClick()
    {
        var clip =_audioClips.FirstOrDefault(t=> t.name == Letter.ToString());
        _audioSource.PlayOneShot(clip);
        _correctClicks++;
        
    CounterText counterText = FindObjectOfType<CounterText>();
    
    if (counterText != null)
    {
        counterText.SetRemaining(_correctAnswers - _correctClicks);
    }
    else
    {
        Debug.LogError("CounterText object not found in the scene.");
    }
    
        if (_correctClicks >= _correctAnswers)
        {
            
            UpdateDisplayLetter();
            _correctClicks = 0;
            GenerateBoard();
        }
       
    }
internal void HandleWrongLetterClick()
    {
        _audioSource.PlayOneShot(bipClip);
    }
    

    private void UpdateDisplayLetter()
    {
        foreach (var displayLetter in FindObjectsOfType<DisplayLetter>())
        {
            displayLetter.SetLetter(Letter);
        }
    }
}
