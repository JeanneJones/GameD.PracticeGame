using System.Collections;
using TMPro;
using UnityEngine;

public class LetterByLetterText : MonoBehaviour
{
    private TMP_Text textComponent;
    public float initialPause = 2f;
    public float letterDelay = 0.1f;
    public float buttonDelay = 1f; // Delay before the Next button appears

    private string fullText = "Hmmmm ... \nThe spirits seem restless today. Let's see if they need anything!";
    private string currentText = "";

    public GameObject nextButton; // Reference to the Next button
    public AudioSource dialogAudio; // Reference to the AudioSource for the dialog sound effect

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = "";
        nextButton.SetActive(false);
        StartCoroutine(ShowTextLetterByLetter());
    }

    private IEnumerator ShowTextLetterByLetter()
    {
        int initialPauseFrames = Mathf.CeilToInt(initialPause / Time.deltaTime);
        int dots = 3;

        // Track the position within the text
        int textPosition = 0;

        for (int i = 0; i < fullText.Length; i++)
        {
            if (i == 9)
            {
                // Pause the audio and text simultaneously
                dialogAudio.Pause();
                yield return new WaitForSeconds(initialPause);
                dialogAudio.UnPause();
            }
            else if (i >= 10 && i < 11)
            {
                currentText += ".";
                textComponent.text = currentText;
                dots++;
                yield return new WaitForSeconds(letterDelay);
            }
            else
            {
                currentText += fullText[i];
                textComponent.text = currentText;
                textPosition++;

                if (textPosition == 9)
                {
                    // Pause the audio when the text pauses
                    dialogAudio.Pause();
                }

                yield return new WaitForSeconds(letterDelay);
            }
        }

        yield return new WaitForSeconds(buttonDelay);
        nextButton.SetActive(true);

        // Stop the dialog sound once the text is fully displayed
        dialogAudio.Stop();
    }
}
