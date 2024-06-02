using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class script : MonoBehaviour
{
    // Start is called before the first frame update
    public float vitesse;
        public TextMeshProUGUI countText;
        public TextMeshProUGUI winText;
        private Rigidbody2D rb;
        private int count;
         private int score;
 //pour pouvoir appliquer une force
        void Start () {
            rb = GetComponent <Rigidbody2D> ();
            count = 0;
             score = 0;

            // SetCountText ();
            winText.text = "";

        }
    

    void FixedUpdate () {
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
            Vector2 mouvement = new Vector2 (moveHorizontal, moveVertical);
            // rb.AddForce (mouvement * vitesse);
            rb.velocity = mouvement * vitesse;
            }
       public void OnTriggerEnter2D (Collider2D other) {
                if (other.gameObject.CompareTag ("point")) {
                    Debug.Log("Collision avec un objet portant le tag 'point'");
                other.gameObject.SetActive (false) ;
                count = count + 1;
                score = score + 10;
                SetCountText ();

                }else{
                    score = score - 10;
                    SetCountText ();
                }
                if(score < 0)  countText.text = "Attention!";
                }
       void SetCountText ()
                      {
                      countText.text = "score: " + score.ToString ();
                      if (count >= 7)
                      {
                      winText.text = "You Win! your score is:"+score ;
                      }
}
public void AddPointsToGlobalScore(int points)
    {
        if (scores.Instance != null)
        {
            scores.Instance.AddScore(points);
        }
    }
}
