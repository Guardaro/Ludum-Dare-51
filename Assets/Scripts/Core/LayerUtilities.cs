using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerUtilities : MonoBehaviour
{
	public static LayerMask CreateMask(Layer[] maskLayers)
	{
		string[] layers = new string[maskLayers.Length];
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i] = maskLayers[i].ToString();
		}
		return (LayerMask.GetMask(layers));
	}

	public static LayerMask CreateMask(Layer maskLayer)
	{
		Layer[] maskLayers = new Layer[1] { maskLayer };
		return CreateMask(maskLayers);
	}

	public static ContactFilter2D CreateFilter(Layer[] layers)
	{
		ContactFilter2D filter = new ContactFilter2D();
		filter.layerMask = CreateMask(layers);
		filter.useLayerMask = true;
		filter.useTriggers = true;
		return filter;
	}

	public static ContactFilter2D CreateFilter(Layer layer)
	{
		Layer[] maskLayers = new Layer[1] { layer };
		return CreateFilter(maskLayers);
	}

}