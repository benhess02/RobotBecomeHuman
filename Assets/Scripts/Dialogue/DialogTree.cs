using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogTree : MonoBehaviour
{
    public TextAsset script;
    public TMP_Text textElement;
    public TMP_Text optionsTextElement;

    private DialogNode currentNode;

    void Start()
    {
        currentNode = DialogParser.Parse(script.text);
        NextChoice();
    }

    void NextChoice()
    {
        bool done = false;
        while (!done)
        {
            if(currentNode == null)
            {
                done = true;
            }
            else if (currentNode is DialogChoiceNode choice)
            {
                textElement.text = choice.text;
                string optionsText = "";
                for(int i = 0; i < choice.options.Count; i++)
                {
                    optionsText += "[" + (i + 1) + "] " + choice.options[i].text + "\n";
                }
                optionsTextElement.text = optionsText;
                done = true;
            }
            else
            {
                currentNode = currentNode.next;
            }
        }
    }

    void ChooseOption(int index)
    {
        if (currentNode is DialogChoiceNode choice)
        {
            if (index >= 0 && index < choice.options.Count)
            {
                currentNode = choice.options[index].next;
                NextChoice();
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChooseOption(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChooseOption(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChooseOption(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChooseOption(3);
        }
    }
}
