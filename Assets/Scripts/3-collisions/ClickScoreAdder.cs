using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NumberField))]
public class ClickScoreAdder : MonoBehaviour
{
    [SerializeField] protected InputAction addAction = new InputAction(type: InputActionType.Button);
    [SerializeField] protected int scoreToAdd = 1;

    private NumberField numberField;

    private void OnEnable()
    {
        addAction.Enable();
    }

    private void OnDisable()
    {
        addAction.Disable();
    }

    private void Start()
    {
        numberField = GetComponent<NumberField>();
        numberField.SetNumber(1);
    }

    private void Update()
    {
        if (addAction.WasPressedThisFrame())
        {
            numberField.AddNumber(scoreToAdd);
        }
    }
}
