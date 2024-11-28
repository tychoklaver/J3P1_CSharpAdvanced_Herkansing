

using System.Linq;

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public class Level1Scene : SceneBase
{
    private Gate _gate;
    private readonly Player _player;
    private Shield _shield;
    private readonly HealthUI _healthUI;
    private readonly List<Collectable> _collectables = new();
    public bool Level1Collectables { get; private set; }

    public Level1Scene(Game1 pGame, Player pPlayer, HealthUI pHealthUI) : base(pGame) { _player = pPlayer; _healthUI = pHealthUI; }

    public override void LoadContent()
    {
        Random random = new Random();
        _shield = new Shield(_game.Content.Load<Texture2D>("Textures/Shield"), random, _player);
        Collectable collectable = new Collectable(_game.Content.Load<Texture2D>("Textures/Gem"), random, _player);
        Damageable damageable = new Damageable(_game.Content.Load<Texture2D>("Textures/Cactus"), random, _player);

        _objects.Add(collectable);
        _objects.Add(_player);
        _objects.Add(_shield);
        _objects.Add(damageable);
        _objects.Add(_healthUI);

        _collectables.Add(collectable);
    }

    public override void Update(GameTime pGameTime)
    {
        base.Update(pGameTime);

        int pickedUpCount = _collectables.Count(c => c.IsPickedUp);
        Level1Collectables = pickedUpCount > 0;
    }

    public void SetGate(Gate pGate)
    {
        _gate = pGate;
        _objects.Add(_gate);
    }
}
