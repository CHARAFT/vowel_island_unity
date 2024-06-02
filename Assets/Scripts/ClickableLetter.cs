using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class ClickableLetter : MonoBehaviour, IPointerClickHandler
{  char _randomChar;
     public void OnPointerClick(PointerEventData eventData)

    {
    Debug.Log($"Clicked on Letter {_randomChar}");
    if (_randomChar==GameController.Instance.Letter)
    {
        GetComponent<TMP_Text>().color= Color.blue;
        enabled=false;
        GameController.Instance.HandleCorrectLetterClick();
       
    }
    else {
         GetComponent<TMP_Text>().color= Color.red;
         enabled=true;
         GameController.Instance.HandleWrongLetterClick();
    }
    }
  /* private void OnEnable()
    {
        int randomIndex = Random.Range(0, 6);
        
        // Array of vowels and their inverses
        char[] vowels = { 'ǝ', 'ᴉ', 'n', 'a', 'e', 'i', 'o', 'u', 'b', 'd' };
        
        // Get the character at the random index from the array
        _randomChar = vowels[randomIndex];
        
        if (Random.Range(0, 100) > 50)
            GetComponent<TMP_Text>().text = _randomChar.ToString();
        else
            GetComponent<TMP_Text>().text = _randomChar.ToString().ToUpper();
    }*/
    internal void SetLetter(char letter){
        enabled=true;
         GetComponent<TMP_Text>().color= Color.white;
        _randomChar=letter;

            if (Random.Range(0, 100) > 50)
            GetComponent<TMP_Text>().text = _randomChar.ToString();
        else
            GetComponent<TMP_Text>().text = _randomChar.ToString().ToUpper();
        }
       

}
