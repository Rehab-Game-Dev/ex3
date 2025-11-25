using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component reads the "playerScore" static variable from the GAME_STATUS static class
 * into this object's NumberField component.
 */
[RequireComponent(typeof(NumberField))]
public class GameStatusReader : MonoBehaviour
{
    private NumberField numberField;

    private void Awake()
    {
        numberField = GetComponent<NumberField>();
    }

    private void Update()
    {
        numberField.SetNumber(GAME_STATUS.playerScore);
    }
}
