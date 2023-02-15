using SpaceGame;
using UnityEngine;

public class RobotInteractable : Interactable
{
    public override bool CanInteract(Interactor interactor)
    {
        return base.CanInteract(interactor) && interactor.CharacterType == CharacterType.Human && interactor.ItemHolder.ItemId == "battery";
    }
    
    protected override void OnInteractionFinished()
    {
        base.OnInteractionFinished();
       // _currentInteractor.ItemHolder.SetItem(null);

        _batteryLevel = 100f;
    }

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _slowedValue = _characterMovement._speed / 2;
        _batteryLevel = 100f;
        _batteryDrain = 10f;
    }

    private void Update()
    {
        base.Update();
        _batteryLevel = Mathf.Clamp(_batteryLevel, 0, 100);
        
        if (_batteryLevel > 0f)
        {
            _batteryLevel -= Time.deltaTime * _batteryDrain;
        }

        if (_batteryLevel == 0f)
        {
            _characterMovement._speed = _slowedValue;
        }
    }


    [SerializeField] private float _batteryLevel;
    [SerializeField] private float _batteryDrain;
    [SerializeField] private float _slowedValue;
    [SerializeField] private CharacterMovement _characterMovement;
}
