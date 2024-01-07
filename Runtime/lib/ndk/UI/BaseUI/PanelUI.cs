using System;
using lib.ndk.Tool;
using lib.ndk.UI.Tween;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace lib.ndk.UI.BaseUI
{
    [RequireComponent(typeof(DisablePicking))]
    public class PanelUI : MonoBehaviour
    {
        [ReadOnly] [SerializeField] protected GameObject panelGroup;
        [ReadOnly] [SerializeField] protected UITweenManager2 tmShow, tmHide;
        [ReadOnly] [ShowInInspector] public bool IsShow { get; private set; } = false;

        const string SHOW_TWEEN_ID = "show";
        const string HIDE_TWEEN_ID = "hide";

        protected void OnValidate()
        {
            InitTween();
        }

        protected virtual void Awake()
        {
            InitTween();
        }

        [Button]
        protected void InitTween()
        {
            //Debug.Log("Init Tween");
            panelGroup = transform.GetChild(0).gameObject;
            tmShow = new UITweenManager2();
            tmHide = new UITweenManager2();
            tmShow.InitTween(gameObject, SHOW_TWEEN_ID);
            tmHide.InitTween(gameObject, HIDE_TWEEN_ID);
        }

        [Button]
        public virtual void SShow()
        {
            if (IsShow) return;
            //Debug.Log("Show: " + name);

            EnablePanel();
            IsShow = true;
            tmHide.StopAllTween();
            tmShow.Play(OnShowDone);

            onShow?.Invoke();
        }


        [Button]
        public virtual void HHide()
        {
            if (!IsShow) return;
            //Debug.Log("Hide: " + name);

            IsShow = false;
            tmShow.StopAllTween();
            tmHide.Play(OnHideDone);

            onHide?.Invoke();
        }

        public virtual void OnShowDone()
        {
            onShowDoneFixedTransition?.Invoke();
            onShowDone?.Invoke();
            //Debug.Log("Show Done: " + name);
        }

        public virtual void OnHideDone()
        {
            onHideDoneFixedTransision?.Invoke();
            onHideDone?.Invoke();
            DisablePanel();
            //Debug.Log("Hide Done: " + name);
            //DisablePanel();
        }


        public void EnablePanel()
        {
            panelGroup.SetActive(true);
        }

        public void DisablePanel()
        {
            panelGroup.SetActive(false);
        }

        public Action onShowDoneFixedTransition;
        public Action onShow;
        public Action onShowDone;
        public Action onHideDoneFixedTransision;
        public Action onHide;
        public Action onHideDone;
    }
}