using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Vaerydian.Utils;

namespace Vaerydian.Generators
{
    public static class CaveGen
    {
        /// <summary>
        /// number of paramebers for CaveGen
        /// </summary>
        public const short CAVE_PARAMS_SIZE = 7;
        
        /// <summary>
        /// parameter index for maps size in x-dimesnion
        /// </summary>
        public const short CAVE_PARAMS_X = 0;
        
        /// <summary>
        /// parameter index for maps size in y-dimension
        /// </summary>
        public const short CAVE_PARAMS_Y = 1;
        
        /// <summary>
        /// parameter index for close cell probability
        /// </summary>
        public const short CAVE_PARAMS_PROB = 2;
        
        /// <summary>
        /// parameter index for cell operation specifier [h=true, if c>n close else open; h=false if c>n open else close]
        /// </summary>
        public const short CAVE_PARAMS_CELL_OP_SPEC = 3;
        
        /// <summary>
        /// parameter index for number of iterations
        /// </summary>
        public const short CAVE_PARAMS_ITER = 4;

        /// <summary>
        /// parameter index for number of cell's close neighbords
        /// </summary>
        public const short CAVE_PARAMS_NEIGHBORS = 5;

        /// <summary>
        /// cave's specific random seed
        /// </summary>
        public const int CAVE_PARAMS_SEED = 6;

        private static Random c_Random = new Random();

        private static String c_StatusMessage = "Generating Cave...";

        public static String StatusMessage
        {
            get { return c_StatusMessage; }
            set { c_StatusMessage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static bool generate( Map map, object[] parameters)
        {
            try
            {
                generateMap( map,
                            (int)parameters[CAVE_PARAMS_X],
                            (int)parameters[CAVE_PARAMS_Y],
                            (int)parameters[CAVE_PARAMS_PROB],
                            (bool)parameters[CAVE_PARAMS_CELL_OP_SPEC],
                            (int)parameters[CAVE_PARAMS_ITER],
                            (int)parameters[CAVE_PARAMS_NEIGHBORS],
                            (int)parameters[CAVE_PARAMS_SEED]);
            }
            catch (Exception e)
            {
				Console.Error.WriteLine(e.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// set terrain to blocking
        /// </summary>
        /// <param name="terrain">terrain to be set</param>
        private static void setBlocking( Terrain terrain, params object[] args) { terrain.IsBlocking = true; }

        /// <summary>
        /// set terrain to not blocking
        /// </summary>
        /// <param name="terrain">terrain to be set</param>
        private static void setNotBlocking( Terrain terrain, params object[] args) { terrain.IsBlocking = false; }

        /// <summary>
        /// randomly sets terrain using the passed probability
        /// </summary>
        /// <param name="terrain">terrain to be changed</param>
        /// <param name="args">arguments containing probability [0]</param>
        private static void setRandom( Terrain terrain, params object[] args)
        {
            int prob = (int)args[0];
            
            //randomly set it
            if (c_Random.Next(100) <= prob)
            {
                //terrain.TerrainType = TerrainType_Old.CAVE_WALL;
                //terrain.IsBlocking = true;
				terrain = setTerrain( terrain, "CAVE_DEFAULT","WALL");
            }
            else
            {
                //terrain.TerrainType = TerrainType_Old.CAVE_FLOOR;
                //terrain.IsBlocking = false;
				terrain = setTerrain( terrain, "CAVE_DEFAULT","FLOOR");
            }
        }

        /// <summary>
        /// creates a random map with the following parameters
        /// </summary>
        /// <param name="map">map to be used</param>
        /// <param name="x">width</param>
        /// <param name="y">height</param>
        /// <param name="prob">close cell probability (0-100)</param>
        /// <param name="h">cell operation specifier [h=true, if c>n close else open; h=false if c>n open else close]</param>
        /// <param name="iter">number of iterations</param>
        /// <param name="n">number of cells neighbors</param>
        /// <returns></returns>
        public static void generateMap( Map map, int x, int y, int prob, bool h, int iter, int n, int seed)
        {

            //initialize
            MapHelper.floodInitializeAll( map, TerrainType_Old.CAVE_WALL);

            //set the seed
            map.Seed = seed;
            c_Random = new Random(map.Seed);

            //fill map as blocking
            MapHelper.floodAllOp( map, setBlocking); 

            //set floor
            MapHelper.floodFillSpecificOp( map, 1, 1, x - 1, y - 1, TerrainType_Old.CAVE_FLOOR, setNotBlocking);

            //randomize map
            MapHelper.floodSpecificOp( map, 1, 1, x - 1, y - 1, setRandom, prob);

            int rX, rY;

            for (int i = 0; i <= iter; i++)
            {
                rX = c_Random.Next(1, x - 1);
                rY = c_Random.Next(1, y - 1);


                Terrain terrain = map.Terrain[rX, rY];

                if (h)
                {
                    if (MapHelper.countOfType(rX, rY, map, TerrainType_Old.CAVE_WALL) > n)
                    {
                        terrain.TerrainType = TerrainType_Old.CAVE_WALL;
                        terrain.IsBlocking = true;
                        map.Terrain[rX, rY] = terrain;
                    }
                    else
                    {
                        terrain.TerrainType = TerrainType_Old.CAVE_FLOOR;
                        terrain.IsBlocking = false;
                        map.Terrain[rX, rY] = terrain;
                    }
                }
                else
                {
                    if (MapHelper.countOfType(rX, rY, map, TerrainType_Old.CAVE_WALL) > n)
                    {
                        terrain.TerrainType = TerrainType_Old.CAVE_FLOOR;
                        terrain.IsBlocking = false;
                        map.Terrain[rX, rY] = terrain;
                    }
                    else
                    {
                        terrain.TerrainType = TerrainType_Old.CAVE_WALL;
                        terrain.IsBlocking = true;
                        map.Terrain[rX, rY] = terrain;
                    }
                }

              

            }

            MapHelper.floodAllOp(map, addVariation);
        }

        private static void addVariation(Terrain terrain, params object[] args)
        {
            terrain.Variation += (float)(0.125 - (c_Random.NextDouble() * 0.25));
        }

		//TODO: complete this
		private static Terrain setTerrain( Terrain terrain, string mapName, string terrainName){
			MapDef mDef = GameConfig.MapDefs [mapName];

			List<TileDef> tiles = mDef.Tiles [terrainName];

			TerrainDef tDef = tiles [c_Random.Next (0, tiles.Count - 1)].TerrainDef;

			terrain.TerrainDef = tDef;
			terrain.IsBlocking = !tDef.Passible;
			terrain.TerrainType = tDef.ID;

			return terrain;
		}

    }
}
