

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;

public class Gate : Interactable
{
    private readonly Game1 _game1;
    private readonly SceneBase _targetScene;
    private const float COOLDOWN_DURATION = 1.0f;
    private float _cooldown;

    public Gate LinkedGate { private get; set; }

    public Gate(Texture2D pTexture, Random pRandom, Player pPlayer, Game1 pGame1, SceneBase pTargetScene) : base(pTexture, pRandom, pPlayer) 
    {
        _game1 = pGame1;
        _targetScene = pTargetScene;
        _cooldown = 0f;
    }

    public override void Update(GameTime pGameTime)
    {
        base.Update(pGameTime);

        if (_cooldown > 0f)
            _cooldown -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
            
    }

    /// <summary>
    /// The functionality which happens when player interacts with <see cref="Gate"/> object.
    /// </summary>
    /// <param name="pPlayer">Player object used to call interacting logic.</param>
    public override void Interact(Player pPlayer)
    {
        if (_cooldown > 0f) return;

        if (LinkedGate != null)
        {
            pPlayer.Position = LinkedGate.Position;
            LinkedGate.SetCooldown();
        }

        _game1.ChangeScene(_targetScene);
        SetCooldown();
    }

    private void SetCooldown() => _cooldown = COOLDOWN_DURATION;
}
