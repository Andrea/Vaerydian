﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ECSFramework;
using ECSFramework.Utils;

using Vaerydian.Components;

namespace Vaerydian.Systems
{
    class SpriteNormalSystem : EntityProcessingSystem
    {
        
        private Dictionary<String, Texture2D> s_Normals = new Dictionary<string, Texture2D>();
        private GameContainer s_Container;
        private SpriteBatch s_SpriteBatch;
        private ComponentMapper s_PositionMapper;
        private ComponentMapper s_ViewportMapper;
        private ComponentMapper s_SpriteMapper;
        private ComponentMapper s_GeometryMapper;
        private Entity s_Geometry;

        private Entity s_Camera;

        public SpriteNormalSystem(GameContainer gameContainer) : base() 
        {
            this.s_Container = gameContainer;
            this.s_SpriteBatch = gameContainer.SpriteBatch;
        }

        public override void initialize()
        {
            s_PositionMapper = new ComponentMapper(new Position(), e_ECSInstance);
            s_ViewportMapper = new ComponentMapper(new ViewPort(), e_ECSInstance);
            s_SpriteMapper = new ComponentMapper(new Sprite(), e_ECSInstance);
            s_GeometryMapper = new ComponentMapper(new GeometryMap(), e_ECSInstance);
        }

        protected override void preLoadContent(Bag<Entity> entities)
        {
            Sprite sprite;
            String texName;
            
            //pre-load all known textures
            for (int i = 0; i < entities.Size(); i++)
            {
                sprite = (Sprite) s_SpriteMapper.get(entities.Get(i));
                texName = sprite.NormalName;
                if(!s_Normals.ContainsKey(texName))
                    s_Normals.Add(texName, s_Container.ContentManager.Load<Texture2D>(texName));
            }

            //pre-load camera entity reference
            s_Camera = e_ECSInstance.TagManager.getEntityByTag("CAMERA");
            s_Geometry = e_ECSInstance.TagManager.getEntityByTag("GEOMETRY");
        }

        protected override void process(Entity entity)
        {
            Position position = (Position) s_PositionMapper.get(entity);
            Sprite sprite = (Sprite) s_SpriteMapper.get(entity);
            ViewPort viewport = (ViewPort) s_ViewportMapper.get(s_Camera);
            GeometryMap geometry = (GeometryMap)s_GeometryMapper.get(s_Geometry);

            Vector2 pos = position.getPosition();
            Vector2 origin = viewport.getOrigin();
            Vector2 center = viewport.getDimensions() / 2;

            s_SpriteBatch.Begin();

            s_SpriteBatch.Draw(s_Normals[sprite.NormalName], pos + center, null, Color.White, 0f, origin, new Vector2(1), SpriteEffects.None, 0f);

            s_SpriteBatch.End();
        }
    }
}
