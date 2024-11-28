namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public class Shield : Interactable
{
    public Shield(Texture2D pTexture, Random pRandom, Player pPlayer) : base(pTexture, pRandom, pPlayer) { }

    public override void Interact(Player pPlayer)
    {
        pPlayer.EquipShield(this);
    }
}
