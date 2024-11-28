using System.Net.Http.Headers;

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_2;
public class ButtonBase : GameObject
{
    private Rectangle _area;
    private Action _onClick;
    private SpriteFont _font;
    private string _text;

    private MouseState _currentMouseState;
    private MouseState _previousMouseState;

    public ButtonStatus Status { get; private set; }

    public ButtonBase(Texture2D pTexture, Rectangle pPosition, Action pOnClick, SpriteFont pFont, string pText) : base(pTexture) 
    {
        _area = pPosition;
        _onClick = pOnClick;
        Status = ButtonStatus.Normal;
        _font = pFont;
        _text = pText;
    }

    public override void Update(GameTime pGameTime)
    {
        _currentMouseState = Mouse.GetState();

        if (_area.Contains(_currentMouseState.X, _currentMouseState.Y))
        {
            Status = _currentMouseState.LeftButton == ButtonState.Pressed ? ButtonStatus.Pressed : ButtonStatus.Hovered;

            if (_currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
                _onClick?.Invoke();
        }
        else
            Status = ButtonStatus.Normal;

        _previousMouseState = _currentMouseState;
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        Color color = Status switch
        {
            ButtonStatus.Normal => Color.White,
            ButtonStatus.Hovered => Color.Gray,
            ButtonStatus.Pressed => Color.Red,
            _ => Color.White
        };
        DrawText(pSpriteBatch);
        pSpriteBatch.Draw(_texture, _area, color);
    }

    private void DrawText(SpriteBatch pSpriteBatch)
    {
        Vector2 textSize = _font.MeasureString(_text);
        Vector2 textPosition = new Vector2(
            _area.X + (_area.Width - textSize.X) / 2,
            _area.Y + (_area.Height - textSize.Y) / 2
        );

        pSpriteBatch.DrawString(_font, _text, textPosition, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, _layerDepth + 0.01f);
    }


}
