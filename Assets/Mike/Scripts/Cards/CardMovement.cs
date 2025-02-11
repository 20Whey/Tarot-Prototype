using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	private RectTransform rectTransform;
	private Canvas canvas;

	private Vector2 ogPointerPos;
	private Vector3 ogPanelPos;

	private Vector3 ogScale;
	private Quaternion ogRotation;
	private Vector3 ogPos;

	[SerializeField] private int currentState = 0;
	[SerializeField] private float hoverScale = 1.1f;
	[SerializeField] private Vector2 cardPlay;
	[SerializeField] private Vector3 playPosition;
	[SerializeField] private GameObject highlightEffect;
	[SerializeField] private GameObject playArrow;
	[SerializeField] private float dragDelay = 0.1f;

	void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvas = GetComponentInParent<Canvas>();
		ogScale = rectTransform.localScale;
		ogPos = rectTransform.localPosition;
		ogRotation = rectTransform.localRotation;
	}

	void Update()
	{
		switch (currentState)
		{
			case 1:
				HandleHoverState();
				break;
			case 2:
				HandleDragState();
				if (!Input.GetMouseButton(0))
				{
					TransitionToState0();
				}
				break;
			case 3:
				HandlePlayState();
				if (!Input.GetMouseButton(0))
				{
					TransitionToState0();
				}
				break;
		}
	}

	private void TransitionToState0()
	{
		currentState = 0;
		rectTransform.localScale = ogScale;
		rectTransform.localPosition = ogPos;
		rectTransform.localRotation = ogRotation;
		highlightEffect.SetActive(false);
		playArrow.SetActive(false);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (currentState == 0)
		{
			ogScale = rectTransform.localScale;
			ogPos = rectTransform.localPosition;
			ogRotation = rectTransform.localRotation;

			currentState = 1;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (currentState == 1)
		{
			TransitionToState0();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (currentState == 1)
		{
			currentState = 2;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out ogPointerPos);
			ogPanelPos = rectTransform.localPosition;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (currentState == 2)
		{
			Vector2 localPointerPosition;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPointerPosition))
			{
				rectTransform.position = Vector3.Lerp(rectTransform.position, Input.mousePosition, dragDelay);

				//Change this into drag and drop slot mechanic bomba skibidi
				if (rectTransform.localPosition.y > cardPlay.y)
				{
					currentState = 3;
					playArrow.SetActive(true);
					rectTransform.localPosition = Vector3.Lerp(rectTransform.position, playPosition, dragDelay);
				}
			}
		}
	}

	private void HandleHoverState()
	{
		highlightEffect.SetActive(true);
		rectTransform.localScale = ogScale * hoverScale;
	}

	private void HandleDragState()
	{
		rectTransform.localRotation = Quaternion.identity;
	}

	private void HandlePlayState()
	{
		rectTransform.localPosition = playPosition;
		rectTransform.localRotation = Quaternion.identity;

		if (Input.mousePosition.y < cardPlay.y)
		{
			currentState = 2;
			playArrow.SetActive(false);
			rectTransform.position = Input.mousePosition;
		}
	}
}
