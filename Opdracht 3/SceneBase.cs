namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public abstract class SceneBase
{
    protected Game1 _game;
    protected List<GameObject> _objects = new();

    protected SceneBase(Game1 pGame)
    {
        _game = pGame;
    }

    public virtual void OnSceneEnter() { }
    public virtual void OnSceneExit() { }

    public virtual void LoadContent() { }
    public virtual void Update(GameTime pGameTime)
    {
        _objects.ForEach(obj => obj.Update(pGameTime));
    }
    
    public virtual void Draw(SpriteBatch pSpriteBatch)
    {
        _objects.ForEach(obj => obj.Draw(pSpriteBatch));
    }
}
