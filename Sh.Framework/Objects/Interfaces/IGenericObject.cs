using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Objects.Interfaces
{

    //this shit's scary
    public interface IGenericObject
    {
        void LoadContent();

        void Update();

        void Draw(SpriteBatch batch);
    }
}
