﻿using UnityEngine;
using System.Collections;

public class Drunk : MonoBehaviour 
{
	public Material material;

	public void OnRenderImage (RenderTexture source, RenderTexture destination) 
	{	
		Graphics.Blit (source, destination, material);
	}
}