using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public Vector2 moveInput;
    public Renderer shieldRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();

        int colorIndex = PlayerPrefs.GetInt("ShieldColor", 0);
        Color targetColor = Color.red;

        Debug.Log(colorIndex);

        if (colorIndex == 0) targetColor = Color.red;
        else if (colorIndex == 1) targetColor = Color.green;
        else if (colorIndex == 2) targetColor = Color.yellow;
        else if (colorIndex == 3) targetColor = Color.blue;

        if (shieldRenderer != null)
        {
            // Works for both Built-in and URP shaders
            shieldRenderer.material.color = targetColor;
            if (shieldRenderer.material.HasProperty("_BaseColor"))
            {
                shieldRenderer.material.SetColor("_BaseColor", targetColor);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.y > 0.5f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);    // Up
        }
        else if (moveInput.y < -0.5f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);  // Down
        }
        else if (moveInput.x < -0.5f)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);   // Left
        }
        else if (moveInput.x > 0.5f)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);  // Right
        }
    }

    public void disableMovement()
    {
        moveAction.Disable();
    }
}
