using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageSpawner : MonoBehaviour
{
    [Header("For Spawner object")]
    [SerializeField] GameObject[] medicTypePrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTrans;
    [SerializeField] float maxTrans;

    [Header("For Timer")]
    [SerializeField] Text timerText;
    [SerializeField] GameObject timerPanel;
    [SerializeField] GameObject shadow;



    bool iSpawn;
    private float timer = 0f;
    private bool isTimerRunning = false;
    #region Singltone
    public static ManageSpawner instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        iSpawn = true;
        StartTimer(10);
        StartSpwner();
    }
    private void Update()
    {
       
    }
    IEnumerator CountToThirty(int timerAmount)
    {
        // Reset the timer
        timer = 0f;
        timerText.text = "0";
        // Start counting from 0 to 30
        for (int i = 0; i <= timerAmount; i++)
        {
            timerText.text = i.ToString();
            this.gameObject.GetComponent<AudioSource>().Play();
            // Wait for 1 second
            yield return new WaitForSeconds(1f);
        }
        // Timer is done
        isTimerRunning = false;
        iSpawn = false;
        shadow.SetActive(true);
        QuestionAnimation.instance.ControlAnimation("Open", timerPanel, 0);
    }
    public void StartTimer(int counter)
    {
        // Reset the timer
        timer = 0f;
        // Start the timer coroutine
        StartCoroutine(CountToThirty(counter));
    }

    public void StopRespawn()
    {
        iSpawn = false;
    }
    public void StartSpwner()
    {
        
        StartCoroutine(SpawnMedic());
    }
    IEnumerator SpawnMedic()
    {
        iSpawn = true;
        print("Spawn");
        yield return new WaitForSeconds(1);
        while (iSpawn)
        {
            var wanted = Random.Range(minTrans, maxTrans);
            var position = new Vector3(wanted, 5.63f);
            GameObject obj = Instantiate(medicTypePrefab[Random.Range(0, medicTypePrefab.Length)],
                position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(obj, 3);
        }
    }
   
}
