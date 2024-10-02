using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [Header("Player Move Var")]
    public float speed;
    public float minX ;
    public float maxX;

    [Header("Progress Bar")]
    public Image progressBarImage;

    [Header("Score....")]
    [SerializeField] private GameObject[] charState;//0 is happy 1 is mid 2 is sad
    [SerializeField] private Text scoreText;
    [SerializeField]private AudioClip []clipsEffect; //0 for 5 _ 1 for 10
    [SerializeField] Text _scoreTextFinal;

    AudioSource audioSource;
    public GameObject player;
    public int score = 0;
    /*public int Score
    {
        get { return score; }
    }*/

    public static PlayerController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        progressBarImage.fillAmount=0;
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            gameObject.AddComponent<AudioSource>();
        }
    }
    private void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {

        if (Input.GetMouseButton(0)) // Check if the left mouse button is pressed
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the mouse position in the world coordinates

            // Calculate the new position based on the mouse position and speed
            Vector3 newPosition = new Vector3(mousePos.x, transform.position.y, transform.position.z);

            // Clamp the new position to stay within the boundaries
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            // Move the player to the new position
            transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Medic5"))
        {
            audioSource.clip = clipsEffect[0];
            audioSource.Play();
            AddScore(5);
        }
        else if (other.CompareTag("Medic10"))
        {
            audioSource.clip = clipsEffect[1];
            audioSource.Play();
            AddScore(10);
        }
        Destroy(other.gameObject);
    }
    public void AddScore(int points)
    {
        score += points;
        HandleChar();
        SetFillAmount(score);
        scoreText.text = score.ToString();

        _scoreTextFinal.text = score.ToString();
    }
    public void SetFillAmount(float amount)
    {
        float fill = amount / 50;
        progressBarImage.fillAmount = fill;
    }
    void HandleChar()
    {
        foreach (GameObject obj in charState){obj.SetActive(false);}
        if (score >=35){ charState[0].SetActive(true);}
        else if (score< 35 && score >=15){ charState[1].SetActive(true);}
        else if (score < 15){ charState[2].SetActive(true);}
    }
    public void ResetVariables()
    {
        progressBarImage.fillAmount = 0;
        charState[2].SetActive(true);
        charState[1].SetActive(false);
        charState[0].SetActive(false);
    }
    
}
