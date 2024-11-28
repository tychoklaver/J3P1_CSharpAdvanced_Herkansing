

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;
public class TitleScreenScene : SceneBase
{
    public TitleScreenScene(Game1 pGame) : base(pGame) { }

    public override void LoadContent()
    {
        Rectangle buttonBounds = new Rectangle((Game1.ScreenWidth - _game.ButtonTexture.Width) / 2, (Game1.ScreenHeight - _game.ButtonTexture.Height) / 2, _game.ButtonTexture.Width, _game.ButtonTexture.Height);
        Action onClickAction = () => _game.ChangeScene(_game.MenuScene);
        _objects.Add(new ButtonBase(_game.ButtonTexture, buttonBounds, onClickAction, _game.Content.Load<SpriteFont>("Fonts/ButtonFont"), "Go to Menu"));
    }
}
