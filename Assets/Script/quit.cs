using UnityEngine;
using UnityEngine.InputSystem;

public class quit : MonoBehaviour
{
    void Update()
    {
        if(Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
    }
}

