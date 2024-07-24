using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
  public static InputManager Instance { get; private set; }

  public InputSystem_Actions InputActions { get; private set; }

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);

      InputActions = new InputSystem_Actions();
      InputActions.Enable();
    }
    else
    {
      Destroy(gameObject);
    }
  }

  private void OnDestroy()
  {
    if (Instance == this)
    {
      InputActions.Disable();
    }
  }
}