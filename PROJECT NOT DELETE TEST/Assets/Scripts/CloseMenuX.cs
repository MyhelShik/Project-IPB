using UnityEngine;
using UnityEngine.InputSystem;

public class CloseMenuX : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private InputActionProperty showButton;

    private void Update()
    {
        if (showButton.action.triggered)
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
