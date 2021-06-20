using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChatBubble : MonoBehaviour
{
	[SerializeField] private TextMeshPro TextMeshProText;
	[SerializeField] private SpriteRenderer backgroundSpriteRenderer;
	[SerializeField] private Vector2 padding;
	[SerializeField, TextArea] private string textField;

	

	

	private void Start()
	{
		TextMeshProText.SetText(textField);
		TextMeshProText.ForceMeshUpdate();
		Vector2 textSize = TextMeshProText.GetRenderedValues();
		backgroundSpriteRenderer.size = textSize + padding;

		backgroundSpriteRenderer.transform.localPosition = new Vector2(0f, backgroundSpriteRenderer.transform.localPosition.y + textSize.y / 2);
	}
}
