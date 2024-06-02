using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleA : MonoBehaviour
{
    private int collisionCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LetterACollider"))
        {
            collisionCount++;
            Debug.Log("Collision avec un élément de la lettre A !");
            // Ajoutez ici le code pour traiter la collision avec un élément de la lettre A
        }
    }

    void Update()
    {
        // Vérifiez si le joueur a traversé tous les éléments de la lettre A
        if (collisionCount >= 3) // 3 pour le cube et les deux cylindres
        {
            Debug.Log("Tracé de la lettre A terminé !");
            // Ajoutez ici le code pour valider le tracé de la lettre A
        }
    }
}
