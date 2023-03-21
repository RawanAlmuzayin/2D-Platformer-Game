using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectables : MonoBehaviour
{
	int melonCounter = 0;
	int strawberryCounter = 0;
	public TextMeshProUGUI MelonText, StrawberryText;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Melon"))
		{
			melonCounter++;
			Destroy(collision.gameObject);
			MelonText.text = ""+ melonCounter;
		}

		if (collision.gameObject.CompareTag("Strawberry"))
		{
			strawberryCounter++;
			Destroy(collision.gameObject);
			StrawberryText.text=""+ strawberryCounter;
		}
	}
}
