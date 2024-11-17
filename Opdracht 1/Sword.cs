namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_1;
public class Sword : Interactable
{
    public Sword(Texture2D pTexture, Random pRandom, Player pPlayer) : base(pTexture, pRandom, pPlayer) { }

    public override void Interact(Player pPlayer)
    {
        pPlayer.EquipSword(this);
    }
}
