using TMPro;
using UnityEngine;

/**
 * This component should be attached to a TextMeshPro object.
 * It allows feeding an integer number to the text field.
 */
[RequireComponent(typeof(TextMeshPro))]
public class NumberField : MonoBehaviour
{
    private int number;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    public int GetNumber()
    {
        return number;
    }

    public void SetNumber(int newNumber)
    {
        number = newNumber;
        if (textMeshPro != null)
        {
            textMeshPro.text = number.ToString();
        }
    }

    public void AddNumber(int toAdd)
    {
        SetNumber(number + toAdd);
    }
}
