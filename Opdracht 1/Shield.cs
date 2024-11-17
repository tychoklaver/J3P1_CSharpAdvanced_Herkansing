namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_1;
public class Shield : Interactable
{
    public Shield(Texture2D pTexture, Random pRandom) : base(pTexture, pRandom) { }

    public override void Interact(Player pPlayer)
    {
        pPlayer.EquipShield(this);
    }
}
