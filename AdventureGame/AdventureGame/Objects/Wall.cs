using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Sandi_s_Way;
using Debugging;


namespace AdventureGameNamespace
{
    public abstract class Wall : SolidObject
    {
        public Wall()
            : base()
        {
        }
        public Wall(Vector2 position)
            : base(position)
        {
        }
    }
}
