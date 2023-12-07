using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set;}
    public event EventHandler OnSelectedUnitChanged;
    [SerializeField]private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleMoveSelection()) { return; };
            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }
    private bool TryHandleMoveSelection()
    {
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit rayCastHit,float.MaxValue,unitLayerMask))
        {
            if(rayCastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
            
        }
        return false;
    }
    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit=unit;
        OnSelectedUnitChanged?.Invoke(this,EventArgs.Empty);
    }
    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
