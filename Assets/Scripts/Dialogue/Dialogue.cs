using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public Text narrativeText;
    public GameObject nextIndicator;

    [TextArea(5, 50)]
    public string[] lines;
    public float textSpeed;

    private int index;

    private void Start()
    {
        narrativeText.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            narrativeText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        nextIndicator.SetActive(true);
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            narrativeText.text = string.Empty;
            nextIndicator.SetActive(false);
            StartCoroutine(TypeLine());
        }
        else
        {
            SceneManager.LoadSceneAsync("Stage Selection");
        }
    }

    public void FinishSentence()
    {
        if (narrativeText.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            narrativeText.text = lines[index];
            nextIndicator.SetActive(true);
        }
    }
}
