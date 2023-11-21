using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UpdateHealthText : MonoBehaviour
{
    TMP_Text theHealthText;
    // Start is called before the first frame update
    void Start()
    {
        theHealthText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the UI text
         theHealthText.text = "Health: " + Health.Instance.myHealth;
        
    }
}
