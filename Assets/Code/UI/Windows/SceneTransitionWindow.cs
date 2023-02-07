using System;
using System.Threading.Tasks;
using Code.Domain.Visualisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Domain.UI.Interfaces
{
    [RequireComponent(typeof(Animator))]
    public class SceneTransitionWindow : MonoBehaviour , ISceneTransition
    {
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private string _enterTransitionAnimationKeyName;
        
        private Animator _animator;
        private TaskCompletionSource<bool> _animationEnded = new ();
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public async Task EnterTransitionAsync()
        {
            _animator.SetBool(_enterTransitionAnimationKeyName, true);
            await _animationEnded.Task;
        }

        public async Task ExitTransitionAsync()
        {
            _animator.SetBool(_enterTransitionAnimationKeyName, false);
            await _animationEnded.Task;
        }
        
        public virtual void SetProgress(int progress)
        {
            _progressSlider.value = progress;
        }

        public void AnimationEnded()
        {
            _animationEnded.SetResult(true);
            _animationEnded = new TaskCompletionSource<bool>();
        }
        
       
    }
}