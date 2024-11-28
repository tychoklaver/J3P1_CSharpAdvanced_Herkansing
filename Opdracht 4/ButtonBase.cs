using System.Net.Http.Headers;

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_4;
public class ButtonBase : GameObject
{
    private Rectangle _area;
    private readonly Action _onClick;
    private readonly SpriteFont _font;
    private readonly string _text;

    private MouseState _currentMouseState;
    private MouseState _previousMouseState;

    public ButtonStatus Status { get; private set; }

    public ButtonBase(Texture2D pTexture, Rectangle pPosition, Action pOnClick, SpriteFont pFont, string pText) : base(pTexture) 
    {
        _area = pPosition;
        _onClick = pOnClick ?? throw new ArgumentNullException(nameof(pOnClick));
        _font = pFont ?? throw new ArgumentNullException(nameof(pFont));
        _text = pText ?? string.Empty;
        Status = ButtonStatus.Normal;
    }

    public override void Update(GameTime pGameTime)
    {
        UpdateMouseState();
        HandleMouseInteraction();
    }

    public override void Draw(SpriteBatch pSpriteBatch)
    {
        DrawButton(pSpriteBatch);
        DrawText(pSpriteBatch);
    }

    private void UpdateMouseState() => _currentMouseState = Mouse.GetState();

    private void HandleMouseInteraction()
    {
        if (_area.Contains(_currentMouseState.Position))
        {
            Status = _currentMouseState.LeftButton == ButtonState.Pressed ? ButtonStatus.Pressed : ButtonStatus.Hovered;
            HandleClick();
        }
        else
            Status = ButtonStatus.Normal;

        _previousMouseState = _currentMouseState;
    }

    private void HandleClick()
    {
        if (_currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
            _onClick?.Invoke();
    }

    private void DrawButton(SpriteBatch pSpriteBatch)
    {
        Color color = Status switch
        {
            ButtonStatus.Normal => Color.White,
            ButtonStatus.Hovered => Color.Gray,
            ButtonStatus.Pressed => Color.Red,
            _ => Color.White
        };
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
