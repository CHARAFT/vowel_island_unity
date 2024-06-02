using UnityEngine;
using TMPro;
public class sc : MonoBehaviour
{
    public float vitesse;
        public TextMeshProUGUI countText;
        public TextMeshProUGUI winText;
        private Rigidbody2D rb;
        private int count;
 //pour pouvoir appliquer une force
        void Start () {
            rb = GetComponent <Rigidbody2D> ();
            count = 0;
            SetCountText ();
            winText.text = "";

        }
        void FixedUpdate () {
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
            Vector2 mouvement = new Vector2 (moveHorizontal, moveVertical);
            // rb.AddForce (mouvement * vitesse);
            rb.velocity = mouvement * vitesse;
            }
       public void OnTriggerEnter (Collider other) {
                if (other.gameObject.CompareTag ("Cible")) {
                other.gameObject.SetActive (false) ;
                count = count + 1;
                SetCountText ();

                }
                }
       void SetCountText ()
                      {
                      countText.text = "Count: " + count.ToString ();
                      if (count >= 8)
                      {
                      winText.text = "You Win!";
                      }
}

}
