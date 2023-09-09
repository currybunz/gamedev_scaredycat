using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    private bool isMouseClick = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            
            if (i < fullText.Length && !isMouseClick)
            {
                yield return new WaitForSeconds(delay);
            }
        }
    }

    void Update()
    {
        if (!isMouseClick && Input.GetMouseButtonDown(0))
        {
            // If a mouse click occurs, set isMouseClick to true
            // to instantly display the entire text.
            isMouseClick = true;
        }
    }
}
