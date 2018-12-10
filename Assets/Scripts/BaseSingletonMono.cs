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
public class BaseSingletonMono<T> : MonoBehaviour where T : MonoBehaviour {

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

	/// <summary>
	/// 継承先で Awake() を使う場合は Awake()内の先頭で base.Awake() を呼び出す
	/// 例）
	/// protected override void Awake() {
	///		base.Awake();
	///		
	///		Awake処理
	/// }
	/// </summary>
	protected virtual void Awake() {
		Debug.Log(typeof(T).ToString() + " awake!");
		if (instance != null) Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		instance = this as T;
	}
}