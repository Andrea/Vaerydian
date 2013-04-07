﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vaerydian.Utils
{
	public struct MapType
	{
		public string Name;
		public short ID;
	}

	public struct MapDef{
		public string Name;
		public short ID;
	}

    public class Map
    {
                
        public Map(int xSize, int ySize)
        {
            m_xSize = xSize;
            m_ySize = ySize;
            m_Terrain = new Terrain[m_xSize, m_ySize];
        }

        private int m_xSize = 100;
        /// <summary>
        /// size of map in x-dimension
        /// </summary>
        public int XSize
        {
            get { return m_xSize; }
            set { m_xSize = value; }
        }

        private int m_ySize = 100;
        /// <summary>
        /// size of map in y-dimension
        /// </summary>
        public int YSize
        {
            get { return m_ySize; }
            set { m_ySize = value; }
        }

        private short m_MapType = 0;
        /// <summary>
        /// type of map
        /// </summary>
        public short MapType
        {
            get { return m_MapType; }
            set { m_MapType = value; }
        }

        private Terrain[,] m_Terrain;
        /// <summary>
        /// map's terrain
        /// </summary>
        public Terrain[,] Terrain
        {
            get { return m_Terrain; }
            set { m_Terrain = value; }
        }

        private int m_Seed;
        /// <summary>
        /// map's random seed
        /// </summary>
        public int Seed
        {
            get { return m_Seed; }
            set { m_Seed = value; }
        }

    }
}
