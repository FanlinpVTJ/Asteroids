using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class JoystickMain : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image joystickArea;
    [SerializeField] private Image joystickBackground;
    [SerializeField] private Image joystick;

    [SerializeField] Color joysticInActive;
    [SerializeField] Color joysticActive;

    private Vector2 joystickBackgroundStartPosition;
    //private Vector2 joystickInputArea;
    protected Vector2 inputVector;
    protected bool joysticActiveBool = false;

    void Start()
    {
        ClickEffect();
        joystickBackgroundStartPosition = joystickBackground.rectTransform.anchoredPosition;
        //joystickInputArea = new Vector2(joystickArea.rectTransform.sizeDelta.x, joystickArea.rectTransform.sizeDelta.y);
    }

    private void ClickEffect()
    {
        if (!joysticActiveBool)
        {
            joystick.color = joysticActive;
            joysticActiveBool = true;
        }
        else
        {
            joystick.color = joysticInActive;
            joysticActiveBool = false;
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform,
            eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = (joystickPosition.x * 2 / joystickBackground.rectTransform.sizeDelta.x);
            joystickPosition.y = (joystickPosition.y * 2 / joystickBackground.rectTransform.sizeDelta.y);

            inputVector = new Vector2(joystickPosition.x, joystickPosition.y);
            inputVector = (inputVector.magnitude > 1f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * joystickBackground.rectTransform.sizeDelta.x / 2,
                inputVector.y * joystickBackground.rectTransform.sizeDelta.y / 2);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickEffect();
        Vector2 joystickBackgroundPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform,
            eventData.position, null, out joystickBackgroundPosition))
        {
            joystickBackground.rectTransform.anchoredPosition = joystickBackgroundStartPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickBackground.rectTransform.anchoredPosition = joystickBackgroundStartPosition;
        ClickEffect();
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
}
