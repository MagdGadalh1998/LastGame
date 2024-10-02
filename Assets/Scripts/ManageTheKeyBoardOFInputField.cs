using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageTheKeyBoardOFInputField : MonoBehaviour
{
    public KeyboardScript keyboardScript = new KeyboardScript();
    public static ManageTheKeyBoardOFInputField instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeInput(InputField field)
    {
        keyboardScript.TextField = field;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
