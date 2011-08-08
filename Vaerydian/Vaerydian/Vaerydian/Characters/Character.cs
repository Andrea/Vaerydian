﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vaerydian.Skills;
using Vaerydian.Abilities;
using Microsoft.Xna.Framework;

namespace Vaerydian.Characters
{
    public enum Alignment
    {
        Good,
        Neutral,
        Evil
    }

    public enum Personality
    {
        Extrovert,
        Introvert
    }


    public abstract class Character
    {
        /// <summary>
        /// name of character
        /// </summary>
        private String c_Name;
        /// <summary>
        /// name of character
        /// </summary>
        public String Name
        {
            get { return c_Name; }
            set { c_Name = value; }
        }

        /// <summary>
        /// health of character
        /// </summary>
        private int c_Health;
        /// <summary>
        /// health of character
        /// </summary>
        public int Health
        {
            get { return c_Health; }
            set { c_Health = value; }
        }

        /// <summary>
        /// how strong and mighty a character is
        /// </summary>
        private int c_Strength;
        /// <summary>
        /// how strong and mighty a character is
        /// </summary>
        public int Strength
        {
            get { return c_Strength; }
            set { c_Strength = value; }
        }
        
        /// <summary>
        /// how dexterous and agile a character is
        /// </summary>
        private int c_Agility;
        /// <summary>
        /// how dexterous and agile a character is
        /// </summary>
        public int Agility
        {
            get { return c_Agility; }
            set { c_Agility = value; }
        }

        /// <summary>
        /// how stout and enduring a character is
        /// </summary>
        private int c_Endurance;
        /// <summary>
        /// how stout and enduring a character is
        /// </summary>
        public int Endurance
        {
            get { return c_Endurance; }
            set { c_Endurance = value; }
        }

        /// <summary>
        /// how learned and studious a character is
        /// </summary>
        private int c_Intelligence;
        /// <summary>
        /// how learned and studious a character is
        /// </summary>
        public int Intelligence
        {
            get { return c_Intelligence; }
            set { c_Intelligence = value; }
        }

        /// <summary>
        /// how wise and insightful characer is
        /// </summary>
        private int c_Wisdom;
        /// <summary>
        /// how wise and insightful characer is
        /// </summary>
        public int Wisdom
        {
            get { return c_Wisdom; }
            set { c_Wisdom = value; }
        }

        /// <summary>
        /// How commanding a character's presence is
        /// </summary>
        private int c_Presence;
        /// <summary>
        /// How commanding a character's presence is
        /// </summary>
        public int Presence
        {
            get { return c_Presence; }
            set { c_Presence = value; }
        }

        /// <summary>
        /// how quick a character is
        /// </summary>
        private int c_Quickness;
        /// <summary>
        /// how quick a character is
        /// </summary>
        public int Quickness
        {
            get { return c_Quickness; }
            set { c_Quickness = value; }
        }

        /// <summary>
        /// how strong a character's will is
        /// </summary>
        private int c_Willpower;
        /// <summary>
        /// how strong a character's will is
        /// </summary>
        public int Willpower
        {
            get { return c_Willpower; }
            set { c_Willpower = value; }
        }

        /// <summary>
        /// how much attention a character pays to their surroundings
        /// </summary>
        private int c_Perception;

        /// <summary>
        /// how much attention a character pays to their surroundings
        /// </summary>
        public int Perception
        {
            get { return c_Perception; }
            set { c_Perception = value; }
        }

        /// <summary>
        /// Alighnment of character
        /// </summary>
        private Alignment c_Alignment;
        /// <summary>
        /// Alighnment of character
        /// </summary>
        public Alignment Alignment
        {
            get { return c_Alignment; }
            set { c_Alignment = value; }
        }

        /// <summary>
        /// Personality of characer
        /// </summary>
        private Personality c_Personality;
        /// <summary>
        /// Personality of characer
        /// </summary>
        public Personality Personality
        {
            get { return c_Personality; }
            set { c_Personality = value; }
        }

        /// <summary>
        /// Character's available skills
        /// </summary>
        private List<Skill> c_Skills;
        /// <summary>
        /// Character's available skills
        /// </summary>
        public List<Skill> Skills
        {
            get { return c_Skills; }
            set { c_Skills = value; }
        }

        /// <summary>
        /// Characer's available Abilities
        /// </summary>
        private List<Ability> c_Abilities;

        internal List<Ability> Abilities
        {
            get { return c_Abilities; }
            set { c_Abilities = value; }
        }

        
        /// <summary>
        /// Character's current battle position
        /// </summary>
        private Vector2 c_BattlePosition;

        /// <summary>
        /// Character's current battle position
        /// </summary>
        public Vector2 BattlePosition
        {
            get { return c_BattlePosition; }
            set { c_BattlePosition = value; }
        }

        /// <summary>
        /// Character's current world position
        /// </summary>
        private Vector2 c_WorldPosition;

        /// <summary>
        /// Character's current world position
        /// </summary>
        public Vector2 WorldPosition
        {
            get { return c_WorldPosition; }
            set { c_WorldPosition = value; }
        } 
        
    }
}
