using UnityEngine;
using UnityEngine.UI;

public class Equation: MonoBehaviour
{
    [SerializeField] private Text equationText;

    [HideInInspector]
    public char numValue;

    private Button buttonComponent;

    private void Awake()
    {
        buttonComponent = GetComponent<Button>();
        if (buttonComponent)
        {
            buttonComponent.onClick.AddListener(() => NumberSelected());
        }
    }

    public void SetNumber(char value)
    {
        equationText.text = value + "";
        numValue = value;
    }

    private void NumberSelected()
    {
        //EquationController.instance.SelectedOption(this);
    }

}
