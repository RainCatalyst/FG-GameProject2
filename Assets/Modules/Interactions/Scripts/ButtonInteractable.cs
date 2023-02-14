using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceGame
{
    public class ButtonInteractable : Interactable
    {
        public event Action<ButtonInteractable> Interacted; // Invoked when someone interacts with it
        public bool IsButtonDisabled
        {
            get => _isButtonDisabled;
            set => _isButtonDisabled = value;
        }

        public void SetTimeWindowProgress(float progress) => _timeWindowBubble.fillAmount = progress;

        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && !_isButtonDisabled &&
                   (_characterType == CharacterType.Any || _characterType == interactor.CharacterType);
        }

        protected override void OnInteractionFinished()
        {
            base.OnInteractionFinished();
            Interacted?.Invoke(this);
            SetTimeWindowProgress(0);
            print("Interacted!");
        }

        private bool _isButtonDisabled;
        [SerializeField] private Image _timeWindowBubble;
        [SerializeField] private CharacterType _characterType;
    }
}