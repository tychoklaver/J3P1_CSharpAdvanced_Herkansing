using System;

namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_3;
public class GameObject
{
    protected Texture2D _texture;
    protected Vector2 _position;
    protected Color _color;
    protected float _rotation;
    protected Vector2 _origin;
    protected Vector2 _scale;
    protected float _layerDepth;

    /// <summary>
    /// The position of where the object gets rendered.
    /// </summary>
    public Vector2 Position
    {
        get => _position; set => _position = value;
    }

    /// <summary>
    /// The bounding rectangle of the object, used for collision.
    /// </summary>
    public Rectangle Rectangle
    {
        get
        {
            if (_texture == null)
                throw new InvalidOperationException("Texture not found."); // Throws error when no texture is added.

            return new Rectangle(
                (int)(_position.X - _origin.X),
                (int)(_position.Y - _origin.Y),
                _texture.Width,
                _texture.Height
            );
        }
    }

    /// <summary>
    /// Initializes a new instance of the GameObject class.
    /// </summary>
    /// <param name="pTexture">The Texture for the object.</param>
    public GameObject(Texture2D pTexture)
    {
        _texture = pTexture;
        _color = Color.White;
        _rotation = 0f;
        _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        _scale = Vector2.One;
        _layerDepth = 0.0f;

        InitializePosition();
    }

    public virtual void Update(GameTime pGameTime)
    {

    }

    public virtual void Draw(SpriteBatch pSpriteBatch)
    {
        if (_texture == null || this is HealthUI) return;
        pSpriteBatch.Draw(_texture, _position, null, _color, _rotation, _origin, _scale, SpriteEffects.None, _layerDepth);
    }

    public void DrawText(SpriteBatch pSpriteBatch, SpriteFont pFont, string pText, Vector2 pPosition)
    {
        Vector2 textSize = pFont.MeasureString(pText);
        Vector2 textPosition = pPosition - textSize / 2;

        pSpriteBatch.DrawString(pFont, pText, textPosition, Color.White);
    }

    private void InitializePosition()
    {
        Random random = new Random();
        Position = new Vector2(
            random.Next((int)_origin.X, Game1.ScreenWidth + (int)_origin.X),
            random.Next((int)_origin.Y, Game1.ScreenHeight + (int)_origin.Y)
        );
    }
}
