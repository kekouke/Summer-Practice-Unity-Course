using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float _rotationX;
    float _rorationY;

    public MouseRotation mouseRotation;

    public enum MouseRotation
    {
        Vertical,
        Horizontal
    }

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        switch (mouseRotation)
        {
            case MouseRotation.Vertical:
                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
                break;
            case MouseRotation.Horizontal:
                _rotationX -= Input.GetAxis("Mouse Y");
                _rotationX = Mathf.Clamp(_rotationX, -45, 45);
                transform.localEulerAngles = new Vector3(_rotationX, _rorationY, 0);
                break;
        }
    }
}
