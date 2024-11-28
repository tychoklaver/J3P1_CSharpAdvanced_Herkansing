namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;
public abstract class EnemyStateBase
{
    protected Enemy _enemy;

    public EnemyStateBase(Enemy pEnemy)
    {
        _enemy = pEnemy;
    }

    public abstract void UpdateState(GameTime pGameTime);
}
