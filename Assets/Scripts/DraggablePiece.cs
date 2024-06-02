using UnityEngine;

public class DraggablePiece : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 lastPosition;

    public float minMoveDistance = 300f; // Distance minimale pour un mouvement significatif
    public script1 script1Ref; // Référence au script1 pour gérer le score et la victoire

    private float startTime;
    private float elapsedTime = 0f; // Ajout de la variable elapsedTime


    private void OnMouseDown()
    {
        isDragging = true;
        lastPosition = transform.position;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startTime = Time.time; // Démarrer l'horloge au début du déplacement

        Debug.Log("Mouse Down Detected");
    }

    private void OnMouseUp()
    {
        isDragging = false;
        elapsedTime = Time.time - startTime; // Arrêter l'horloge lorsque le déplacement est terminé
        script1Ref.UpdateElapsedTime(elapsedTime); // Mettre à jour elapsedTime dans script1
        script1Ref.OnPieceDrag(); // Ajouter cette ligne pour mettre à jour le nombre de tentatives

        Debug.Log("Mouse Up Detected. Elapsed Time: " + elapsedTime);
    }


    private void Update()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;

            // Calculer la distance du déplacement
            float distance = Vector3.Distance(transform.position, lastPosition);
            if (distance > minMoveDistance)
            {
                // Incrémenter le score et vérifier la condition de victoire
                script1Ref.IncreaseScore(1);
                lastPosition = transform.position;

                Debug.Log("Distance parcourue : " + distance);
            }
        }
    }
}
