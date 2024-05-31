using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            CheckHit();
        }
    }

    void CheckHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null && hit.collider.CompareTag("Circle"))
        {
            Destroy(hit.collider.gameObject);
            score++;
            UpdateScore();
        }
        else
        {
            GameOver();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        // Add game over logic here
    }
}
