using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 汎用型シングルトンクラス
/// 継承して使う
/// </summary>
/// <typeparam name="T">
/// 継承先のクラス自身を指定
/// 例) public class AAA : SingletonMonoBehaviour&lt;AAA&gt; {}
/// </typeparam>
public abstract class BaseSingletonMono<T> : MonoBehaviour where T : MonoBehaviour {

	protected static T instance;

	protected BaseSingletonMono() { }

	public static T Instance {
		get {
			if (instance == null) {
				GameObject obj = new GameObject(typeof(T).ToString() + "(singleton)");
				instance = obj.AddComponent<T>();
			}

			return instance;
		}
	}

	protected virtual void Awake() {
		if (instance != null) Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		instance = this as T;
	}
}