using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorExWindow : EditorWindow {
	// menuのWindowにEditorExという項目を追加する
	[MenuItem("Window/EditorEx")]
	static void Open() {
		// EditorExを選択するとOpen()が呼ばれる
		// 表示させたいウィンドウは基本的にGetWindow()で表示＆取得する
		EditorWindow.GetWindow<EditorExWindow>( "EditorWindow" );
	}

	// Windowクライアント領域のGUI処理
	void OnGUI() {
		EditorGUILayout.LabelField("Unityエディタ拡張");
	}
}
