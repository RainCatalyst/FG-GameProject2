using System;
using System.Collections;
using System.Collections.Generic;
using SpaceGame;
using Unity.VisualScripting;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
   private void Awake()
   {
      _oxygenLevel = 99f;
      _damageMultiplier = 0;
   }

   private void Update()
   {
      if (_damageMultiplier != 0)
      {
         _oxygenLevel -= _damageMultiplier * Time.deltaTime;
         _oxygenBar.Progress = _oxygenLevel;
      }
      else
      {
         _oxygenLevel += _oxygenRegainLevel * Time.deltaTime;
         _oxygenBar.Progress = _oxygenLevel;
      }

      _oxygenLevel = Mathf.Clamp(_oxygenLevel, 0, 100);
   }

   private void OnEnable()
   {
      _repairInteractable[0].Damaged += DamageMultiply;
      _repairInteractable[1].Damaged += DamageMultiply;
      _repairInteractable[2].Damaged += DamageMultiply;
      _repairInteractable[3].Damaged += DamageMultiply;
      
      _repairInteractable[0].Repaired +=  DamageDivide;
      _repairInteractable[1].Repaired +=  DamageDivide;
      _repairInteractable[2].Repaired +=  DamageDivide;
      _repairInteractable[3].Repaired +=  DamageDivide;
   }

   private void OnDisable()
   {
      // _repairInteractable[0].Damaged -= () =>  DamageMultiply();
      // _repairInteractable[1].Damaged -= () =>  DamageMultiply();
      // _repairInteractable[2].Damaged -= () =>  DamageMultiply();
      // _repairInteractable[3].Damaged -= () =>  DamageMultiply();
      //
      // _repairInteractable[0].Repaired -= () => DamageDivide();
      // _repairInteractable[1].Repaired -= () => DamageDivide();
      // _repairInteractable[2].Repaired -= () => DamageDivide();
      // _repairInteractable[3].Repaired -= () => DamageDivide();
   }
   
   public void DamageMultiply()
   {
      _damageMultiplier++;
   }
   public void DamageDivide()
   {
      _damageMultiplier--;
   }


   [SerializeField] private float _oxygenRegainLevel = 1f;
   [SerializeField] private float _oxygenLevel;
   [SerializeField] private int _damageMultiplier;
   [SerializeField] private ProgressBar _oxygenBar;
   [SerializeField] private RepairInteractable[] _repairInteractable;
}

