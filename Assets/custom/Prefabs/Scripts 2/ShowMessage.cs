using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowMessage : MonoBehaviour
{
    private bool isColliding = false;

    private void Start()
    {
        // Disable the text at the start
        TMP_Text textPop = GameObject.FindGameObjectWithTag("TextPop").GetComponent<TMP_Text>();
        textPop.enabled = false;
    }

    private void Update()
    {
        if (!isColliding)
        {
            Transform player = transform;
            Transform whisp = GameObject.FindGameObjectWithTag("TextPop").transform;
            float distance = Vector2.Distance(whisp.position, player.position);

            TMP_Text textPop = GameObject.FindGameObjectWithTag("TextPop").GetComponent<TMP_Text>();

            if (distance < 1.5)
            {
                textPop.enabled = true;
                textPop.text = "Oh no, my pumpkin is unlit! Can you help me?";
            }
            else
            {
                textPop.enabled = false;
            }
        }
    }


    ///Later use?
    /*private void OnTriggerEnter2D(Collider2D col)
{
if (col.gameObject.tag == "TextPop")
{
 TMP_Text textPop = GameObject.FindGameObjectWithTag("TextPop").GetComponent<TMP_Text>();
 textPop.text = "t";
 textPop.enabled = true;
}
isColliding = true;
}

private void OnTriggerExit2D(Collider2D col)
{
if (col.gameObject.tag == "TextPop")
{
 TMP_Text textPop = GameObject.FindGameObjectWithTag("TextPop").GetComponent<TMP_Text>();
 textPop.enabled = false;
}
isColliding = false;
}*/

}
