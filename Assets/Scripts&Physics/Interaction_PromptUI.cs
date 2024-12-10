using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction_PromptUI : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private GameObject button;
    [SerializeField] private TextMeshProUGUI promptText;

    private void Start()
    {
        uiPanel.SetActive(false);
    }

    public bool IsDisplayed = false;
    public void SetUp(string textPrompt)
    {
        promptText.text = textPrompt;
        uiPanel.SetActive(true);
        button.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        button.SetActive(false);
        uiPanel.SetActive(false);
        IsDisplayed = false;
    }

}
