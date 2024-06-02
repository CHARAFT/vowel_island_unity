using UnityEngine;

public class VoyelleDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer; // Permet de dessiner les lignes
    private Vector2 mousePosition; // Position de la souris
    private bool isDrawing = false; // Indique si le joueur est en train de dessiner

    void Start()
    {
        // Initialisation du LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        // Vérifie si le joueur a cliqué
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        // Vérifie si le joueur est en train de glisser la souris
        else if (Input.GetMouseButton(0))
        {
            if (isDrawing)
            {
                ContinueDrawing();
            }
        }
        // Vérifie si le joueur a relâché le bouton de la souris
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }
    }

    // Début du dessin
    void StartDrawing()
    {
        isDrawing = true;
        lineRenderer.positionCount = 1;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, mousePosition);
    }

    // Suite du dessin
    void ContinueDrawing()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePosition);
    }

    // Fin du dessin
    void StopDrawing()
    {
        isDrawing = false;
    }
}
