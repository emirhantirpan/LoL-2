using UnityEngine;
using UnityEngine.InputSystem;

public class UI_Controller : MonoBehaviour
{
    private InputSystem_Actions _input;
    private ChampionSelectionGameObject _selection;

    private void Start()
    {
        _selection = GetComponent<ChampionSelectionGameObject>();

        _input = new InputSystem_Actions();
        AssignInputs();
    }
    private void AssignInputs()
    {
        //_input.UI.ChampionSelect.performed += ctx => _selection.ChooseChampion();
    }
}
