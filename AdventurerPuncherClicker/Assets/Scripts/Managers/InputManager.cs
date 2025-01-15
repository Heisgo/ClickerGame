using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Actions")]
    public static Action onPunched;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ThrowRaycast();
    }

    private void ThrowRaycast()
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (hit.collider == null) return;
        Debug.Log("Clicked yayyy");
        onPunched?.Invoke();
    }
}
