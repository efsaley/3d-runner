using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;

    // Added new codes
    public PlayerController playerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;
    private InGameRanking ig;
    public Animator PlayerAnim;
    public GameObject EndPanel;
    public GameObject Player;
    public bool isGameFinished;


    private void Start()
    {
        isGameFinished = false;
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
        ig = FindObjectOfType<InGameRanking>();
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //Debug.Log("Coin collected!..");
            AddCoin();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Finish"))
        {
            isGameFinished = true;
            EndPanel.SetActive(true);
            playerController.runningSpeed = 0f;
            if (ig.namesTxt[6].text == "Ayberk")
            {
                Debug.Log("Congrats!..");
                PlayerAnim.SetBool("win",true);
            }
            else
            {
                Debug.Log("You Lose!..");
                 PlayerAnim.SetBool("lose",true);
            }
            
        }
        else if (other.CompareTag("Speedboost"))
        {
            playerController.runningSpeed = playerController.runningSpeed + 3f;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
    }

    void PlayerFinished() {
        playerController.runningSpeed = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            //Debug.Log("Touched Obstacle!..");
            // Added new codes
            transform.position = PlayerStartPos;
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed = playerController.runningSpeed - 3f;
        speedBoosterIcon.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
