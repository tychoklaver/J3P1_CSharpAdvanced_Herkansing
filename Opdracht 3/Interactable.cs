
namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public abstract class Interactable : GameObject
{
    protected Random _random;
    private readonly Player _player;
    public Interactable(Texture2D pTexture, Random pRandom, Player pPlayer) : base(pTexture)
    {
        _random = pRandom;
        _player = pPlayer;
    }

    public override void Update(GameTime pGameTime)
    {
        HandleInteraction(_player);
    }

    /// <summary>
    /// Checks for collision with Player object, then calls interaction functionality logic.
    /// </summary>
    /// <param name="pPlayer">The Player object used to check collision with.</param>
    public void HandleInteraction(Player pPlayer)
    {
        if (pPlayer.Rectangle.Intersects(Rectangle))
            Interact(pPlayer);
    }

    public abstract void Interact(Player pPlayer);
}
