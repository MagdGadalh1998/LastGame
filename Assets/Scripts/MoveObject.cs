using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveObject : MonoBehaviour
{
    
    bool isDragging;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetMouseButtonDown(0))
         {
             print("Moving");
             Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             if (GetComponent<Collider2D>().OverlapPoint(mousePosition))
             {
                 isDragging = true;
             }
         }

         if (isDragging)
         {
             Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             mousePosition.z = transform.position.z;
             transform.position = mousePosition;
         }

         if (Input.GetMouseButtonUp(0))
         {
             isDragging = false;
         }
     }*/

        
    } }

