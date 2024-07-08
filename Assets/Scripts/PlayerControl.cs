using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    float xInput;
    float yInput;
    int score = 0;
    public int WinScore;
    public GameObject winText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
            SceneManager.LoadScene("Game");
    }
    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        rb.AddForce(xInput*speed, 0, yInput*speed);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            score++;
            if(score>= WinScore)
            {
                winText.SetActive(true);
            }
        }
    }
}
