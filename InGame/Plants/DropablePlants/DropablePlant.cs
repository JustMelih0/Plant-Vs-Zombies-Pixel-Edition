using UnityEngine;

public class DropablePlant : PlantBase
{
    [SerializeField]private float shineTime;
    [SerializeField]private string prefabName;
    public override void DestroyObject()
    {
        CancelInvoke(nameof(SunControl));
        base.DestroyObject();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
    protected override void Start()
    {
        base.Start();
    }
    private void SunControl()
    {
        anim.SetTrigger("shine");
    }
    private void SpawnShine()
    {
        PoolManager.Instance.SpawnFromPool(prefabName, transform.position, Quaternion.identity);
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        InvokeRepeating(nameof(SunControl), shineTime, shineTime);
    }
    public override void SetCurrentGrid(GridController newGrid)
    {
        base.SetCurrentGrid(newGrid);
    }

}
