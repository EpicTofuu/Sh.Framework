using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects.Interfaces;
using System.Collections.Generic;

namespace Sh.Framework.Screens
{
    /// <summary>
    /// An (in testing) replacement for the current screen class
    /// aims to purge all Draw logic
    /// </summary>
    public abstract class GameScreen : IDynamic
    {
        protected List <IStationary> stationary = new List<IStationary>();
        protected List <IDynamic> dynamic = new List<IDynamic> ();

        protected ScreenManager s;

        public virtual void LoadContent()
        {
            foreach (IStationary s in stationary) s.LoadContent();
            foreach (IDynamic d in dynamic) d.LoadContent();
        }

        public virtual void UnloadContent()
        {
            foreach (IStationary s in stationary) s.UnloadContent();
            foreach (IDynamic d in dynamic) d.UnloadContent();
        }

        public virtual void Update()
        {
            foreach (IDynamic d in dynamic) d.Update();
        }
        
        public virtual void Draw(SpriteBatch batch)
        {
            foreach (IStationary s in stationary) s.Draw(batch);
            foreach (IDynamic d in dynamic) d.Draw(batch);
        }
    }
}
