namespace J3P1_CSharpAdvanced_Herkansing.Opdracht_1;
public class Player : GameObject
{
    private const float _playerSpeed = 300f;

    public Shield EquippedShield { get; private set; }
    public Sword EquippedSword { get; private set; }

    public Player(Texture2D pTexture) : base(pTexture)
    {
        Random random = new Random();
        _position = new Vector2(random.Next((int)_origin.X, Game1.ScreenWidth - (int)_origin.X), random.Next((int)_origin.Y, Game1.ScreenHeight - (int)_origin.Y));
    }

    public override void Update(GameTime pGameTime)
    {
        KeyboardState currentKeyboardState = Keyboard.GetState();

        PlayerMovement(pGameTime, currentKeyboardState);

        UpdateEquippedPositions();

        base.Update(pGameTime);
    }


    public override void Draw(SpriteBatch pSpriteBatch)
    {
        base.Draw(pSpriteBatch);

        // Draws Shield and Sword on to the player, should they not be null.
        EquippedShield?.Draw(pSpriteBatch);
        EquippedSword?.Draw(pSpriteBatch);
    }

    /// <summary>
    /// Equips shield on to the player object.
    /// </summary>
    /// <param name="pShield">The reference of the shield to be added on.</param>
    public void EquipShield(Shield pShield) => EquippedShield = pShield;

    /// <summary>
    /// Equips sword on to the player object.
    /// </summary>
    /// <param name="pSword">The reference of the sword to be added on.</param>
    public void EquipSword(Sword pSword) => EquippedSword = pSword;

    /// <summary>
    /// Handles player movement.
    /// </summary>
    /// <param name="pGameTime">The current game time.</param>
    /// <param name="pCurrentKeyboardState">The current state of the Keyboard.</param>
    private void PlayerMovement(GameTime pGameTime, KeyboardState pCurrentKeyboardState)
    {
        Vector2 direction = new Vector2(
            pCurrentKeyboardState.IsKeyDown(Keys.D) ? 1 : pCurrentKeyboardState.IsKeyDown(Keys.A) ? -1 : 0,
            pCurrentKeyboardState.IsKeyDown(Keys.S) ? 1 : pCurrentKeyboardState.IsKeyDown(Keys.W) ? -1 : 0 
        );

        if (direction != Vector2.Zero)
            direction.Normalize();

        _position += direction * _playerSpeed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        _position.X = MathHelper.Clamp(_position.X, _origin.X, Game1.ScreenWidth - _origin.X);
        _position.Y = MathHelper.Clamp(_position.Y, _origin.Y, Game1.ScreenHeight - _origin.Y);
    }

    /// <summary>
    /// Updates the positions of the shield and sword, should they be equipped.
    /// </summary>
    private void UpdateEquippedPositions()
    {
        if (EquippedShield != null)
            EquippedShield.Position = _position + new Vector2(-20, 10);

        if (EquippedSword != null)
            EquippedSword.Position = _position + new Vector2(30, 0);
    }
}
