﻿using System.Collections;
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
	bool toggle = false;
	string textField = "";
	string textArea = "";
	string password = "";
	float horizontalScrollbar = 0.0f;
	float verticalScrollbar = 0.0f;
	float horizontalSlider = 0.0f;
	float verticalSlider = 0.0f;
	int toolbar = 0;
	int selectionGrid = 0;

	void OnGUI() {
		EditorGUILayout.LabelField("Unityエディタ拡張!");

		GUILayout.Label("Label: GUILayoutはUnityEngine側なので、ランタイムでもそのまま使える");
		
		if (GUILayout.Button("Button")) {
			Debug.Log("Button tapped!");
		}

		if (GUILayout.RepeatButton("RepeatButton")) {
			Debug.Log("RepeatButton tapped!");
		}

		toggle = GUILayout.Toggle(toggle, "Toggle");

		GUILayout.Label( "TextField" );
		textField = GUILayout.TextField( textField );

		GUILayout.Label( "TextArea" );
		textArea = GUILayout.TextArea( textArea );

		GUILayout.Label( "PasswordField" );
		password = GUILayout.PasswordField( password, '*');

		GUILayout.Label( "HorizontalScrollbar" );
		float horizontalSize = 10.0f;// sizeはバーのサイズ(0～100のスクロールバーで10なので、全体に対して10分の1サイズ)
		horizontalScrollbar = GUILayout.HorizontalScrollbar( horizontalScrollbar,horizontalSize,0.0f,100.0f );

		GUILayout.Label( "VerticalScrollbar" );
		float verticalSize = 10.0f;// sizeはバーのサイズ(0～100のスクロールバーで10なので、全体に対して10分の1サイズ)
		verticalScrollbar = GUILayout.VerticalScrollbar( verticalScrollbar,verticalSize,0.0f,100.0f );

		GUILayout.Label( "HorizontalSlider" );
		horizontalSlider = GUILayout.HorizontalSlider( horizontalSlider,0.0f,100.0f );

		GUILayout.Label( "VerticalSlider" );
		verticalSlider = GUILayout.VerticalSlider( verticalSlider,0.0f,100.0f );

		GUILayout.Label( "Toolbar" );
		toolbar = GUILayout.Toolbar( toolbar,new string[]{ "Tool1","Tool2","Tool3" } );

		GUILayout.Label( "SelectionGrid" );
		selectionGrid = GUILayout.SelectionGrid( selectionGrid,new string[]{ "Grid 1","Grid 2","Grid 3","Grid 4" },2 );

		GUILayout.Box( "Box" );

		GUILayout.Label( "ここからSpace" );
		GUILayout.Space(100);
		GUILayout.Label( "ここまでSpace" );

		GUILayout.Label( "ここからFlexibleSpace" );
		GUILayout.FlexibleSpace();
		GUILayout.Label( "ここまでFlexibleSpace" );
	}
}
