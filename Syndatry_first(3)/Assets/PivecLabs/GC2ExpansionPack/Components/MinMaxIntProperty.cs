using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PivecLabs.MinMaxSliderInt {


	[System.Serializable]
	public class MinMaxType<T> {
		public T min;
		public T max;
	}
	
	[System.Serializable]
	public class MinMaxint : MinMaxType<int> { }
	
	
	[System.AttributeUsage(System.AttributeTargets.Field)]
	public class MinMaxIntAttribute : PropertyAttribute {
		public readonly int MinLimit = 0;
		public readonly int MaxLimit = 1;

		public MinMaxIntAttribute(int min, int max) {
			MinLimit = min;
			MaxLimit = max;
		}
	}
	

}
