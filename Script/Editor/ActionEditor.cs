
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
//アニメーションイベント付与用
public class ActionEditor : EditorWindow
{
    Animator animObject;
    AnimationClip animClip;
    AnimationEvent ev;

    float animClipTime;
    float StartTime;
    string functionName;

    [MenuItem("Window/ActionEditor")]
    static void Open()
    {
        GetWindow<ActionEditor>();
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("character : ", GUILayout.Width(110));
        animObject = (Animator)EditorGUILayout.ObjectField(animObject, typeof(Animator), true);
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("animation clip : ", GUILayout.Width(110));
        animClip = (AnimationClip)EditorGUILayout.ObjectField(animClip, typeof(AnimationClip), true);
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();

       
        GUILayout.BeginHorizontal();
        animClipTime = EditorGUILayout.Slider(new GUIContent("TimeLine"), animClipTime, 0, 1, GUILayout.Width(300));
        GUILayout.EndHorizontal();
        functionName = EditorGUILayout.TextField("FuncName:", functionName);
        EditorGUILayout.Space();

        StartTime = EditorGUILayout.FloatField("starttime",StartTime);

        if (GUILayout.Button("Add Event"))
        {       
            var serialied = new SerializedObject(animClip);
            serialied.Update();

            var events = new List<AnimationEvent>();

            ev = new AnimationEvent();
            ev.time = StartTime;
            ev.functionName = functionName;
            events.Add(ev);

            AnimationUtility.SetAnimationEvents((AnimationClip)serialied.targetObject, events.ToArray());
        }


        if (animObject != null && animClip != null)
        {
            animClip.SampleAnimation(animObject.gameObject, animClipTime);
        }
    }
}
#endif
