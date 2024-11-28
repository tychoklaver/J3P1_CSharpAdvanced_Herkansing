

using System.Linq;

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;
public class Level2Scene : SceneBase
{
    private Gate _gate;
    private readonly Player _player;
    private Sword _sword;
    private readonly HealthUI _healthUI;
    private readonly List<Collectable> _collectables = new();
    public bool Level2Collectables { get; private set; }

    public Level2Scene(Game1 pGame, Player pPlayer, HealthUI pHealthUI) : base(pGame) { _player = pPlayer; _healthUI = pHealthUI; }

    public override void LoadContent()
    {
        Random random = new Random();

        _sword = new Sword(_game.Content.Load<Texture2D>("Textures/Weapon"), random, _player);
        Collectable collectable = new Collectable(_game.Content.Load<Texture2D>("Textures/Gem"), random, _player);
        Damageable damageable = new Damageable(_game.Content.Load<Texture2D>("Textures/Cactus"), random, _player);
        Damageable damageable2 = new Damageable(_game.Content.Load<Texture2D>("Textures/Cactus"), random, _player);

        _objects.Add(collectable);
        _objects.Add(_player);
        _objects.Add(_sword);
        _objects.Add(damageable);
        _objects.Add(damageable2);
        _objects.Add(_healthUI);

        _collectables.Add(collectable);
    }

    public override void Update(GameTime pGameTime)
    {
        base.Update(pGameTime);

        int pickedUpCount = _collectables.Count(c => c.IsPickedUp);
        Level2Collectables = pickedUpCount > 0;
    }

    public void SetGate(Gate pGate)
    {
        _gate = pGate;
        _objects.Add(_gate);
    }
}
