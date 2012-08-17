﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ECSFramework;

using Vaerydian.Components;
using Vaerydian.Components.Characters;
using Vaerydian.Factories;

namespace Vaerydian.Systems.Update
{
    class LifeSystem : EntityProcessingSystem
    {
        private ComponentMapper l_LifeMapper;
        private Entity l_Player;

        private NPCFactory l_NPCFactory;

        public override void initialize()
        {
            l_LifeMapper = new ComponentMapper(new Life(), e_ECSInstance);
            l_NPCFactory = new NPCFactory(e_ECSInstance);
        }

        protected override void preLoadContent(Bag<Entity> entities)
        {
            l_Player = e_ECSInstance.TagManager.getEntityByTag("PLAYER");
        }

        protected override void process(Entity entity)
        {
            Life life = (Life)l_LifeMapper.get(entity);

            //if you're still alive, dont worry about it
            if (life.IsAlive)
                return;

            //don't decay the player yet
            if (entity == l_Player)
                return;

            life.TimeSinceDeath += e_ECSInstance.ElapsedTime;

            if (life.TimeSinceDeath > life.DeathLongevity)
            {
                //cleanup entity
                l_NPCFactory.destroyRelatedEntities(entity);

                //get rid of entity
                e_ECSInstance.deleteEntity(entity);
            }


        }


    }
}