using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingleton<T> where T : class, new() {

	protected static readonly T instance = new T();

	public static T Instance {
		get {
			return instance;
		}
	}
}
