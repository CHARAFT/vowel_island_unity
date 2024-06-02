using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip sonClicBouton; // Le son que vous voulez jouer

    private Button bouton;
    private AudioSource audioSource;

    void Start()
    {
        bouton = GetComponent<Button>(); // Obtenez la référence du composant Button attaché à cet objet
        bouton.onClick.AddListener(JouerSon); // Ajoutez un écouteur pour détecter le clic sur le bouton

        audioSource = GetComponent<AudioSource>(); // Obtenez la référence du AudioSource attaché à cet objet
        audioSource.clip = sonClicBouton; // Définissez le son à jouer
    }

    void JouerSon()
    {
        audioSource.Play(); // Jouez le son lorsque le bouton est cliqué
    }
}
