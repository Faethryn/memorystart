using Memory.Models.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Memory.Views
{

    public class TileView : ViewBaseClass<Tile> , IPointerDownHandler
    {

        private Animator _animator;

        void Start()
        {
            _animator = this.GetComponent<Animator>();
            AddEvents();
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            Model.Board.State.AddPreview(Model);
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Model.State)))
                StartAnimation();
        }

        private void StartAnimation()
        {
            if (Model.State == new TilePreviewingState(Model))
            {
                _animator.Play("Shown");

            }
            if (Model.State == new TileHiddenState(Model))
            {
                _animator.Play("Hidden");

            }
            
        }

        private void AddEvents()
        {
            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                AnimationClip clip = _animator.runtimeAnimatorController.animationClips[i];

                AnimationEvent animationStartEvent = new AnimationEvent();
                animationStartEvent.time = 0;
                animationStartEvent.functionName = "AnimationStartHandler";
                animationStartEvent.stringParameter = clip.name;

                AnimationEvent animationEndEvent = new AnimationEvent();
                animationEndEvent.time = clip.length;
                animationEndEvent.functionName = "AnimationCompleteHandler";
                animationEndEvent.stringParameter = clip.name;

                clip.AddEvent(animationStartEvent);
                clip.AddEvent(animationEndEvent);
            }


        }


        public void AnimationStartHandler(string name)
        {
            Debug.Log($"{name} animation start.");

        }
        public void AnimationCompleteHandler(string name)
        {
            Debug.Log($"{name} animation complete.");

        }

    }
}