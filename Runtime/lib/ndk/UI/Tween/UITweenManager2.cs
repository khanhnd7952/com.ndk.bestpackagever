using System;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace lib.ndk.UI.Tween
{
    [Serializable]
    public class UITweenManager2
    {
        [ReadOnly] [SerializeField] protected GameObject parent;
        [ReadOnly] [SerializeField] protected List<DOTweenAnimation> tweens;
        [ReadOnly] [SerializeField] protected DOTweenAnimation longestTween;
        [ReadOnly] [SerializeField] protected string tweenId;

        public void InitTween(GameObject parent, string id)
        {
            this.parent = parent;
            tweenId = id;

            DOTweenAnimation[] allTweens = this.parent.GetComponentsInChildren<DOTweenAnimation>(true);

            tweens = new List<DOTweenAnimation>();

            var longestShow = float.MinValue;
            foreach (DOTweenAnimation tween in allTweens)
            {


                if (tween.isActive && tween.duration > 0 && tween.id == tweenId)
                {
                    tween.autoGenerate = false;
                    tween.autoPlay = false;
                    tween.autoKill = false;
                    tween.loops = 1;
                    tween.isIndependentUpdate = true;

                    var tweenTime = tween.delay + tween.duration;
                    if (tweenTime > longestShow)
                    {
                        longestShow = tweenTime;
                        longestTween = tween;
                    }

                    tweens.Add(tween);
                }
            }

            if (longestTween != null)
            {
                longestTween.hasOnComplete = true;
                longestTween.onComplete = new UnityEvent();
                longestTween.onComplete.RemoveAllListeners();
                longestTween.onComplete.AddListener(OnPlayComplete);
            }
        }

        private void OnPlayComplete()
        {
            //Debug.Log("Play Complete");
            //Debug.Log("onPlayComplete:" + (onPlayComplete == null));

            onPlayComplete?.Invoke();
        }

        public void Play(Action onDone)
        {
            if (tweens.IsNullOrEmpty())
            {
                onDone?.Invoke();
                return;
            }

            //Debug.Log("Play ");

            onPlayComplete = onDone;
            //Debug.Log("onPlayComplete:" + (onPlayComplete == null));


            StopAllTween();
            foreach (DOTweenAnimation doTweenAnimation in tweens)
            {
                doTweenAnimation.CreateTween(false, false);
                doTweenAnimation.DORestartById(tweenId);
                doTweenAnimation.DOPlayById(tweenId);
            }

            // longestTween.hasOnComplete = true;
            // longestTween.onComplete = new UnityEvent();
            // longestTween.onComplete.RemoveAllListeners();
            // longestTween.onComplete.AddListener(OnPlayComplete);
        }

        public void StopAllTween()
        {
            foreach (DOTweenAnimation doTweenAnimation in tweens)
            {
                doTweenAnimation.DOPause();
            }
        }

        Action onPlayComplete;
    }
}