using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LatitudeDirectionImage : MonoBehaviour
{
	[SerializeField]
	private Image directionImage; // Image component representing the direction

	[SerializeField]
	private Sprite northSprite; // Sprite for North direction
	[SerializeField]
	private Sprite southSprite; // Sprite for South direction

	public void SetDirectionImage(LatitudeDirection direction)
	{
		switch (direction)
		{
			case LatitudeDirection.North:
				directionImage.sprite = northSprite;
				break;
			case LatitudeDirection.South:
				directionImage.sprite = southSprite;
				break;
		}
	}
}

public enum LatitudeDirection
{
	North,
	South
}
