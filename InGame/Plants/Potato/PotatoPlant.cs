using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoPlant : PlantBase
{
    private float idlePos = 0f;
    public override void DestroyObject()
    {
        base.DestroyObject();
    }
    protected override void Initialize()
    {
        base.Initialize();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        idlePos = 0f;
    }
    public override void SetCurrentGrid(GridController newGrid)
    {
        base.SetCurrentGrid(newGrid);
    }
    protected override void Start()
    {
        base.Start();
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (health  <= 70)
        {
            idlePos = 1f;
        }
        else if (health <= 140)
        {
            idlePos = 0.5f;
        }
        anim.SetFloat("idlePos", idlePos); 
    }
    
}
