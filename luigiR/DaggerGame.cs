using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace daggersRage
{
    public class DaggerGame
    {


        public int levelwidth;
        public int levelheight;
        public int halfblock;
        public int BLOCKSIZE = 16;
        public int nextid = 0;

        //public DaggerBlock[,] blockarray;

        
        //public PlayerObject singleplayer;
        public PlayerController playerInput;
        public PointObject testPoint;
       // public PointObject[] pointArray;
        public List<PointObject> pointArray;
        public List<PhysicsObject> playerArray;
        public List<BlockUpdate> updatedblocks;
        public int[][] blockarray;

        public bool locked;


        public DaggerGame()
        {
            testPoint = new PointObject(nextid);
            pointArray = new List<PointObject>();
            playerArray = new List<PhysicsObject>();
            updatedblocks = new List<BlockUpdate>();
            nextid++;
            this.halfblock = 8;
            this.levelheight = 50;
            this.levelwidth = 150;


            this.locked = false;

            playerInput = new PlayerController();
            //singleplayer = new PlayerObject(playerInput);
            

            blockarray = new int[levelwidth][];

            for (int i = 0; i < levelwidth; i++)
            {
                blockarray[i] = new int[levelheight];

                for(int j = 0; j < levelheight; j++)
                {

                    if ((i == levelwidth-2) || (i == 1) || (j == levelheight-2) || (j == 1))
                    {

                        blockarray[i][j] = 3;

                    }
                    else
                    {

                        blockarray[i][j] = 0;
                    }

                }

            }
            
            blockarray[0][1] = 3;
blockarray[0][48] = 3;
blockarray[1][0] = 3;
blockarray[1][1] = 3;
blockarray[1][2] = 3;
blockarray[1][3] = 1;
blockarray[1][4] = 2;
blockarray[1][5] = 3;
blockarray[1][6] = 3;
blockarray[1][7] = 3;
blockarray[1][8] = 3;
blockarray[1][9] = 3;
blockarray[1][10] = 3;
blockarray[1][11] = 3;
blockarray[1][12] = 3;
blockarray[1][13] = 3;
blockarray[1][14] = 3;
blockarray[1][15] = 3;
blockarray[1][16] = 3;
blockarray[1][17] = 3;
blockarray[1][18] = 3;
blockarray[1][19] = 3;
blockarray[1][20] = 3;
blockarray[1][21] = 3;
blockarray[1][22] = 3;
blockarray[1][23] = 3;
blockarray[1][24] = 3;
blockarray[1][25] = 3;
blockarray[1][26] = 3;
blockarray[1][27] = 3;
blockarray[1][28] = 3;
blockarray[1][29] = 3;
blockarray[1][30] = 3;
blockarray[1][31] = 3;
blockarray[1][32] = 3;
blockarray[1][33] = 3;
blockarray[1][34] = 3;
blockarray[1][35] = 3;
blockarray[1][36] = 3;
blockarray[1][37] = 3;
blockarray[1][38] = 3;
blockarray[1][39] = 3;
blockarray[1][40] = 3;
blockarray[1][41] = 3;
blockarray[1][42] = 3;
blockarray[1][43] = 3;
blockarray[1][44] = 3;
blockarray[1][45] = 3;
blockarray[1][46] = 3;
blockarray[1][47] = 3;
blockarray[1][48] = 3;
blockarray[1][49] = 3;
blockarray[2][1] = 3;
blockarray[2][48] = 3;
blockarray[3][1] = 3;
blockarray[3][48] = 3;
blockarray[4][1] = 3;
blockarray[4][15] = 3;
blockarray[4][48] = 3;
blockarray[5][1] = 3;
blockarray[5][15] = 3;
blockarray[5][48] = 3;
blockarray[6][1] = 3;
blockarray[6][15] = 3;
blockarray[6][48] = 3;
blockarray[7][1] = 3;
blockarray[7][15] = 3;
blockarray[7][48] = 3;
blockarray[8][1] = 3;
blockarray[8][15] = 3;
blockarray[8][48] = 3;
blockarray[9][1] = 3;
blockarray[9][15] = 3;
blockarray[9][48] = 3;
blockarray[10][1] = 3;
blockarray[10][48] = 3;
blockarray[11][1] = 3;
blockarray[11][48] = 3;
blockarray[12][1] = 3;
blockarray[12][35] = 3;
blockarray[12][45] = 3;
blockarray[12][48] = 3;
blockarray[13][1] = 3;
blockarray[13][35] = 3;
blockarray[13][45] = 3;
blockarray[13][48] = 3;
blockarray[14][1] = 3;
blockarray[14][35] = 3;
blockarray[14][45] = 3;
blockarray[14][48] = 3;
blockarray[15][1] = 3;
blockarray[15][35] = 3;
blockarray[15][45] = 3;
blockarray[15][48] = 3;
blockarray[16][1] = 3;
blockarray[16][35] = 3;
blockarray[16][45] = 3;
blockarray[16][48] = 3;
blockarray[17][1] = 3;
blockarray[17][48] = 3;
blockarray[18][1] = 3;
blockarray[18][48] = 3;
blockarray[19][1] = 3;
blockarray[19][48] = 3;
blockarray[20][1] = 3;
blockarray[20][48] = 3;
blockarray[21][1] = 3;
blockarray[21][48] = 3;
blockarray[22][1] = 3;
blockarray[22][48] = 3;
blockarray[23][1] = 3;
blockarray[23][48] = 3;
blockarray[24][1] = 3;
blockarray[24][48] = 3;
blockarray[25][1] = 3;
blockarray[25][48] = 3;
blockarray[26][1] = 3;
blockarray[26][46] = 3;
blockarray[26][48] = 3;
blockarray[27][1] = 3;
blockarray[27][45] = 3;
blockarray[27][48] = 3;
blockarray[28][1] = 3;
blockarray[28][17] = 2;
blockarray[28][44] = 3;
blockarray[28][48] = 3;
blockarray[29][1] = 3;
blockarray[29][43] = 3;
blockarray[29][48] = 3;
blockarray[30][1] = 3;
blockarray[30][15] = 2;
blockarray[30][43] = 3;
blockarray[30][48] = 3;
blockarray[31][1] = 3;
blockarray[31][43] = 3;
blockarray[31][48] = 3;
blockarray[32][1] = 3;
blockarray[32][43] = 3;
blockarray[32][48] = 3;
blockarray[33][1] = 3;
blockarray[33][43] = 3;
blockarray[33][48] = 3;
blockarray[34][1] = 3;
blockarray[34][25] = 2;
blockarray[34][48] = 3;
blockarray[35][1] = 3;
blockarray[35][25] = 3;
blockarray[35][48] = 3;
blockarray[36][1] = 3;
blockarray[36][25] = 3;
blockarray[36][48] = 3;
blockarray[37][1] = 3;
blockarray[37][25] = 3;
blockarray[37][48] = 3;
blockarray[38][1] = 3;
blockarray[38][25] = 3;
blockarray[38][31] = 3;
blockarray[38][48] = 3;
blockarray[39][1] = 3;
blockarray[39][28] = 3;
blockarray[39][31] = 3;
blockarray[39][42] = 3;
blockarray[39][43] = 3;
blockarray[39][44] = 3;
blockarray[39][45] = 3;
blockarray[39][46] = 3;
blockarray[39][48] = 3;
blockarray[40][1] = 3;
blockarray[40][31] = 3;
blockarray[40][42] = 3;
blockarray[40][48] = 3;
blockarray[41][1] = 2;
blockarray[41][42] = 3;
blockarray[41][48] = 3;
blockarray[42][1] = 3;
blockarray[42][33] = 3;
blockarray[42][42] = 3;
blockarray[42][48] = 3;
blockarray[43][1] = 3;
blockarray[43][33] = 3;
blockarray[43][42] = 3;
blockarray[43][48] = 3;
blockarray[44][1] = 3;
blockarray[44][33] = 3;
blockarray[44][48] = 3;
blockarray[45][1] = 3;
blockarray[45][33] = 3;
blockarray[45][48] = 3;
blockarray[46][1] = 1;
blockarray[46][48] = 3;
blockarray[47][1] = 3;
blockarray[47][35] = 3;
blockarray[47][42] = 3;
blockarray[47][48] = 3;
blockarray[48][1] = 1;
blockarray[48][42] = 3;
blockarray[48][48] = 3;
blockarray[49][1] = 3;
blockarray[49][42] = 3;
blockarray[49][43] = 3;
blockarray[49][44] = 3;
blockarray[49][45] = 3;
blockarray[49][46] = 3;
blockarray[49][47] = 3;
blockarray[49][48] = 3;
blockarray[50][1] = 1;
blockarray[50][35] = 3;
blockarray[50][48] = 3;
blockarray[51][1] = 3;
blockarray[51][48] = 3;
blockarray[52][1] = 3;
blockarray[52][48] = 3;
blockarray[53][1] = 3;
blockarray[53][48] = 3;
blockarray[54][1] = 3;
blockarray[54][38] = 3;
blockarray[54][48] = 3;
blockarray[55][1] = 3;
blockarray[55][38] = 3;
blockarray[55][48] = 3;
blockarray[56][1] = 3;
blockarray[56][38] = 3;
blockarray[56][48] = 3;
blockarray[57][1] = 3;
blockarray[57][41] = 3;
blockarray[57][48] = 3;
blockarray[58][1] = 3;
blockarray[58][41] = 3;
blockarray[58][44] = 3;
blockarray[58][48] = 3;
blockarray[59][1] = 3;
blockarray[59][48] = 3;
blockarray[60][1] = 3;
blockarray[60][48] = 3;
blockarray[61][1] = 3;
blockarray[61][46] = 3;
blockarray[61][48] = 3;
blockarray[62][1] = 3;
blockarray[62][46] = 3;
blockarray[62][48] = 3;
blockarray[63][1] = 3;
blockarray[63][48] = 3;
blockarray[64][1] = 3;
blockarray[64][48] = 3;
blockarray[65][1] = 3;
blockarray[65][48] = 3;
blockarray[66][1] = 3;
blockarray[66][48] = 3;
blockarray[67][1] = 3;
blockarray[67][48] = 3;
blockarray[68][0] = 3;
blockarray[68][1] = 3;

blockarray[68][45] = 3;
blockarray[68][46] = 3;
blockarray[68][47] = 3;
blockarray[68][48] = 3;
blockarray[68][49] = 3;
blockarray[69][1] = 3;
blockarray[69][48] = 3;
blockarray[70][1] = 3;
blockarray[70][48] = 3;
blockarray[71][1] = 3;
blockarray[71][48] = 3;
blockarray[72][1] = 3;
blockarray[72][48] = 3;
blockarray[73][1] = 3;
blockarray[73][48] = 3;
blockarray[74][1] = 3;
blockarray[74][48] = 3;
blockarray[75][1] = 3;
blockarray[75][48] = 3;
blockarray[76][1] = 3;
blockarray[76][48] = 3;
blockarray[77][1] = 3;
blockarray[77][48] = 3;
blockarray[78][1] = 3;
blockarray[78][48] = 3;
blockarray[79][1] = 3;
blockarray[79][48] = 3;
blockarray[80][1] = 3;
blockarray[80][48] = 3;
blockarray[81][1] = 3;
blockarray[81][48] = 3;
blockarray[82][1] = 3;
blockarray[82][48] = 3;
blockarray[83][1] = 3;
blockarray[83][48] = 3;
blockarray[84][1] = 3;
blockarray[84][48] = 3;
blockarray[85][1] = 3;
blockarray[85][48] = 3;
blockarray[86][1] = 3;
blockarray[86][48] = 3;
blockarray[87][1] = 3;
blockarray[87][48] = 3;
blockarray[88][1] = 3;
blockarray[88][48] = 3;
blockarray[89][1] = 3;
blockarray[89][48] = 3;
blockarray[90][1] = 3;
blockarray[90][48] = 3;
blockarray[91][1] = 3;
blockarray[91][48] = 3;
blockarray[92][1] = 3;
blockarray[92][48] = 3;
blockarray[93][1] = 3;
blockarray[93][48] = 3;
blockarray[94][1] = 3;
blockarray[94][48] = 3;
blockarray[95][1] = 3;
blockarray[95][48] = 3;
blockarray[96][1] = 3;
blockarray[96][48] = 3;
blockarray[97][1] = 3;
blockarray[97][48] = 3;
blockarray[98][1] = 3;
blockarray[98][48] = 3;
blockarray[99][1] = 3;
blockarray[99][48] = 3;
blockarray[100][1] = 3;
blockarray[100][48] = 3;
blockarray[101][1] = 3;
blockarray[101][48] = 3;
blockarray[102][1] = 3;
blockarray[102][48] = 3;
blockarray[103][1] = 3;
blockarray[103][48] = 3;
blockarray[104][1] = 3;
blockarray[104][48] = 3;
blockarray[105][1] = 3;
blockarray[105][48] = 3;
blockarray[106][1] = 3;
blockarray[106][48] = 3;
blockarray[107][1] = 3;
blockarray[107][48] = 3;
blockarray[108][1] = 3;
blockarray[108][48] = 3;
blockarray[109][1] = 3;
blockarray[109][48] = 3;
blockarray[110][1] = 3;
blockarray[110][48] = 3;
blockarray[111][1] = 3;
blockarray[111][48] = 3;
blockarray[112][1] = 3;
blockarray[112][48] = 3;
blockarray[113][1] = 3;
blockarray[113][48] = 3;
blockarray[114][1] = 3;
blockarray[114][48] = 3;
blockarray[115][1] = 3;
blockarray[115][48] = 3;
blockarray[116][1] = 3;
blockarray[116][48] = 3;
blockarray[117][1] = 3;
blockarray[117][48] = 3;
blockarray[118][1] = 3;
blockarray[118][48] = 3;
blockarray[119][1] = 3;
blockarray[119][48] = 3;
blockarray[120][1] = 3;
blockarray[120][48] = 3;
blockarray[121][1] = 3;
blockarray[121][48] = 3;
blockarray[122][1] = 3;
blockarray[122][48] = 3;
blockarray[123][1] = 3;
blockarray[123][48] = 3;
blockarray[124][1] = 3;
blockarray[124][48] = 3;
blockarray[125][1] = 3;
blockarray[125][48] = 3;
blockarray[126][1] = 3;
blockarray[126][48] = 3;
blockarray[127][1] = 3;
blockarray[127][48] = 3;
blockarray[128][1] = 3;
blockarray[128][48] = 3;
blockarray[129][1] = 3;
blockarray[129][48] = 3;
blockarray[130][1] = 3;
blockarray[130][48] = 3;
blockarray[131][1] = 3;
blockarray[131][48] = 3;
blockarray[132][1] = 3;
blockarray[132][48] = 3;
blockarray[133][1] = 3;
blockarray[133][48] = 3;
blockarray[134][1] = 3;
blockarray[134][48] = 3;
blockarray[135][1] = 3;
blockarray[135][48] = 3;
blockarray[136][1] = 3;
blockarray[136][48] = 3;
blockarray[137][1] = 3;
blockarray[137][48] = 3;
blockarray[138][1] = 3;
blockarray[138][48] = 3;
blockarray[139][1] = 3;
blockarray[139][48] = 3;
blockarray[140][1] = 3;
blockarray[140][48] = 3;
blockarray[141][1] = 3;
blockarray[141][48] = 3;
blockarray[142][1] = 3;
blockarray[142][48] = 3;
blockarray[143][1] = 3;
blockarray[143][48] = 3;
blockarray[144][1] = 3;
blockarray[144][48] = 3;
blockarray[145][1] = 3;
blockarray[145][48] = 3;
blockarray[146][1] = 3;
blockarray[146][48] = 3;
blockarray[147][1] = 3;
blockarray[147][48] = 3;
blockarray[148][0] = 3;
blockarray[148][1] = 3;
blockarray[148][2] = 3;
blockarray[148][3] = 3;
blockarray[148][4] = 3;
blockarray[148][5] = 3;
blockarray[148][6] = 3;
blockarray[148][7] = 3;
blockarray[148][8] = 3;
blockarray[148][9] = 3;
blockarray[148][10] = 3;
blockarray[148][11] = 3;
blockarray[148][12] = 3;
blockarray[148][13] = 3;
blockarray[148][14] = 3;
blockarray[148][15] = 3;
blockarray[148][16] = 3;
blockarray[148][17] = 3;
blockarray[148][18] = 3;
blockarray[148][19] = 3;
blockarray[148][20] = 3;
blockarray[148][21] = 3;
blockarray[148][22] = 3;
blockarray[148][23] = 3;
blockarray[148][24] = 3;
blockarray[148][25] = 3;
blockarray[148][26] = 3;
blockarray[148][27] = 3;
blockarray[148][28] = 3;
blockarray[148][29] = 3;
blockarray[148][30] = 3;
blockarray[148][31] = 3;
blockarray[148][32] = 3;
blockarray[148][33] = 3;
blockarray[148][34] = 3;
blockarray[148][35] = 3;
blockarray[148][36] = 3;
blockarray[148][37] = 3;
blockarray[148][38] = 3;
blockarray[148][39] = 3;
blockarray[148][40] = 3;
blockarray[148][41] = 3;
blockarray[148][42] = 3;
blockarray[148][43] = 3;
blockarray[148][44] = 3;
blockarray[148][45] = 3;
blockarray[148][46] = 3;
blockarray[148][47] = 3;
blockarray[148][48] = 3;
blockarray[148][49] = 3;
blockarray[149][1] = 3;
blockarray[149][48] = 3;
blockarray[0][1] = 3;
blockarray[0][48] = 3;
blockarray[1][0] = 3;
blockarray[1][1] = 3;
blockarray[1][2] = 3;
blockarray[1][3] = 1;
blockarray[1][4] = 2;
blockarray[1][5] = 3;
blockarray[1][6] = 3;
blockarray[1][7] = 3;
blockarray[1][8] = 3;
blockarray[1][9] = 3;
blockarray[1][10] = 3;
blockarray[1][11] = 3;
blockarray[1][12] = 3;
blockarray[1][13] = 3;
blockarray[1][14] = 3;
blockarray[1][15] = 3;
blockarray[1][16] = 3;
blockarray[1][17] = 3;
blockarray[1][18] = 3;
blockarray[1][19] = 3;
blockarray[1][20] = 3;
blockarray[1][21] = 3;
blockarray[1][22] = 3;
blockarray[1][23] = 3;
blockarray[1][24] = 3;
blockarray[1][25] = 3;
blockarray[1][26] = 3;
blockarray[1][27] = 3;
blockarray[1][28] = 3;
blockarray[1][29] = 3;
blockarray[1][30] = 3;
blockarray[1][31] = 3;
blockarray[1][32] = 3;
blockarray[1][33] = 3;
blockarray[1][34] = 3;
blockarray[1][35] = 3;
blockarray[1][36] = 3;
blockarray[1][37] = 3;
blockarray[1][38] = 3;
blockarray[1][39] = 3;
blockarray[1][40] = 3;
blockarray[1][41] = 3;
blockarray[1][42] = 3;
blockarray[1][43] = 3;
blockarray[1][44] = 3;
blockarray[1][45] = 3;
blockarray[1][46] = 3;
blockarray[1][47] = 3;
blockarray[1][48] = 3;
blockarray[1][49] = 3;
blockarray[2][1] = 3;
blockarray[2][48] = 3;
blockarray[3][1] = 3;
blockarray[3][48] = 3;
blockarray[4][1] = 3;
blockarray[4][15] = 3;
blockarray[4][48] = 3;
blockarray[5][1] = 3;
blockarray[5][15] = 3;
blockarray[5][48] = 3;
blockarray[6][1] = 3;
blockarray[6][15] = 3;
blockarray[6][48] = 3;
blockarray[7][1] = 3;
blockarray[7][15] = 3;
blockarray[7][48] = 3;
blockarray[8][1] = 3;
blockarray[8][15] = 3;
blockarray[8][48] = 3;
blockarray[9][1] = 3;
blockarray[9][15] = 3;
blockarray[9][48] = 3;
blockarray[10][1] = 3;
blockarray[10][48] = 3;
blockarray[11][1] = 3;
blockarray[11][48] = 3;
blockarray[12][1] = 3;
blockarray[12][35] = 3;
blockarray[12][45] = 3;
blockarray[12][48] = 3;
blockarray[13][1] = 3;
blockarray[13][35] = 3;
blockarray[13][45] = 3;
blockarray[13][48] = 3;
blockarray[14][1] = 3;
blockarray[14][35] = 3;
blockarray[14][45] = 3;
blockarray[14][48] = 3;
blockarray[15][1] = 3;
blockarray[15][35] = 3;
blockarray[15][45] = 3;
blockarray[15][48] = 3;
blockarray[16][1] = 3;
blockarray[16][35] = 3;
blockarray[16][45] = 3;
blockarray[16][48] = 3;
blockarray[17][1] = 3;
blockarray[17][48] = 3;
blockarray[18][1] = 3;
blockarray[18][48] = 3;
blockarray[19][1] = 3;
blockarray[19][48] = 3;
blockarray[20][1] = 3;
blockarray[20][48] = 3;
blockarray[21][1] = 3;
blockarray[21][48] = 3;
blockarray[22][1] = 3;
blockarray[22][48] = 3;
blockarray[23][1] = 3;
blockarray[23][48] = 3;
blockarray[24][1] = 3;
blockarray[24][48] = 3;
blockarray[25][1] = 3;
blockarray[25][48] = 3;
blockarray[26][1] = 3;
blockarray[26][46] = 3;
blockarray[26][48] = 3;
blockarray[27][1] = 3;
blockarray[27][45] = 3;
blockarray[27][48] = 3;
blockarray[28][1] = 3;
blockarray[28][44] = 3;
blockarray[28][48] = 3;
blockarray[29][1] = 3;
blockarray[29][43] = 3;
blockarray[29][48] = 3;
blockarray[30][1] = 3;
blockarray[30][43] = 3;
blockarray[30][48] = 3;
blockarray[31][1] = 3;
blockarray[31][43] = 3;
blockarray[31][48] = 3;
blockarray[32][1] = 3;
blockarray[32][43] = 3;
blockarray[32][48] = 3;
blockarray[33][1] = 3;
blockarray[33][43] = 3;
blockarray[33][48] = 3;
blockarray[34][1] = 3;
blockarray[34][25] = 2;
blockarray[34][48] = 3;
blockarray[35][1] = 3;
blockarray[35][25] = 3;
blockarray[35][48] = 3;
blockarray[36][1] = 3;
blockarray[36][25] = 3;
blockarray[36][48] = 3;
blockarray[37][1] = 3;
blockarray[37][25] = 3;
blockarray[37][48] = 3;
blockarray[38][1] = 3;
blockarray[38][25] = 3;
blockarray[38][31] = 3;
blockarray[38][48] = 3;
blockarray[39][1] = 3;
blockarray[39][28] = 3;
blockarray[39][31] = 3;
blockarray[39][42] = 3;
blockarray[39][43] = 3;
blockarray[39][44] = 3;
blockarray[39][45] = 3;
blockarray[39][46] = 3;
blockarray[39][48] = 3;
blockarray[40][1] = 3;
blockarray[40][31] = 3;
blockarray[40][42] = 3;
blockarray[40][48] = 3;
blockarray[41][1] = 2;
blockarray[41][42] = 3;
blockarray[41][48] = 3;
blockarray[42][1] = 3;
blockarray[42][33] = 3;
blockarray[42][42] = 3;
blockarray[42][48] = 3;
blockarray[43][1] = 3;
blockarray[43][33] = 3;
blockarray[43][42] = 3;
blockarray[43][48] = 3;
blockarray[44][1] = 3;
blockarray[44][33] = 3;
blockarray[44][48] = 3;
blockarray[45][1] = 3;
blockarray[45][33] = 3;
blockarray[45][48] = 3;
blockarray[46][1] = 1;
blockarray[46][48] = 3;
blockarray[47][1] = 3;
blockarray[47][35] = 3;
blockarray[47][42] = 3;
blockarray[47][48] = 3;
blockarray[48][1] = 1;
blockarray[48][42] = 3;
blockarray[48][48] = 3;
blockarray[49][1] = 3;
blockarray[49][42] = 3;
blockarray[49][43] = 3;
blockarray[49][44] = 3;
blockarray[49][45] = 3;
blockarray[49][46] = 3;
blockarray[49][47] = 3;
blockarray[49][48] = 3;
blockarray[50][1] = 1;
blockarray[50][35] = 3;
blockarray[50][48] = 3;
blockarray[51][1] = 3;
blockarray[51][48] = 3;
blockarray[52][1] = 3;
blockarray[52][48] = 3;
blockarray[53][1] = 3;
blockarray[53][48] = 3;
blockarray[54][1] = 3;
blockarray[54][38] = 3;
blockarray[54][48] = 3;
blockarray[55][1] = 3;
blockarray[55][38] = 3;
blockarray[55][48] = 3;
blockarray[56][1] = 3;
blockarray[56][38] = 3;
blockarray[56][48] = 3;
blockarray[57][1] = 3;
blockarray[57][41] = 3;
blockarray[57][48] = 3;
blockarray[58][1] = 3;
blockarray[58][41] = 3;
blockarray[58][44] = 3;
blockarray[58][48] = 3;
blockarray[59][1] = 3;
blockarray[59][48] = 3;
blockarray[60][1] = 3;
blockarray[60][48] = 3;
blockarray[61][1] = 3;
blockarray[61][46] = 3;
blockarray[61][48] = 3;
blockarray[62][1] = 3;
blockarray[62][46] = 3;
blockarray[62][48] = 3;
blockarray[63][1] = 3;
blockarray[63][48] = 3;
blockarray[64][1] = 3;
blockarray[64][48] = 3;
blockarray[65][1] = 3;
blockarray[65][39] = 3;
blockarray[65][40] = 3;
blockarray[65][48] = 3;
blockarray[66][1] = 3;
blockarray[66][39] = 3;
blockarray[66][40] = 3;
blockarray[66][48] = 3;
blockarray[67][1] = 3;
blockarray[67][48] = 3;
blockarray[68][0] = 3;
blockarray[68][1] = 3;
blockarray[68][2] = 3;
blockarray[68][3] = 3;
blockarray[68][4] = 3;
blockarray[68][5] = 3;
blockarray[68][6] = 3;
blockarray[68][7] = 3;
blockarray[68][8] = 3;
blockarray[68][9] = 3;
blockarray[68][10] = 3;
blockarray[68][11] = 3;
blockarray[68][12] = 3;
blockarray[68][13] = 3;
blockarray[68][14] = 3;
blockarray[68][15] = 3;
blockarray[68][16] = 3;
blockarray[68][17] = 3;
blockarray[68][18] = 3;
blockarray[68][20] = 3;
blockarray[68][21] = 3;
blockarray[68][22] = 3;
blockarray[68][23] = 3;
blockarray[68][24] = 3;
blockarray[68][25] = 3;
blockarray[68][26] = 3;
blockarray[68][27] = 3;
blockarray[68][44] = 3;
blockarray[68][45] = 3;
blockarray[68][46] = 3;
blockarray[68][47] = 3;
blockarray[68][48] = 3;
blockarray[68][49] = 3;
blockarray[69][1] = 3;
blockarray[69][44] = 3;
blockarray[69][48] = 3;
blockarray[70][1] = 3;
blockarray[70][44] = 3;
blockarray[70][48] = 3;
blockarray[71][1] = 3;
blockarray[71][38] = 3;
blockarray[71][39] = 3;
blockarray[71][40] = 3;
blockarray[71][44] = 3;
blockarray[71][48] = 3;
blockarray[72][1] = 3;
blockarray[72][38] = 3;
blockarray[72][40] = 3;
blockarray[72][44] = 3;
blockarray[72][48] = 3;
blockarray[73][1] = 3;
blockarray[73][38] = 3;
blockarray[73][39] = 3;
blockarray[73][40] = 3;
blockarray[73][44] = 3;
blockarray[73][45] = 3;
blockarray[73][46] = 3;
blockarray[73][47] = 3;
blockarray[73][48] = 3;
blockarray[74][1] = 3;
blockarray[74][38] = 3;
blockarray[74][40] = 3;
blockarray[74][48] = 3;
blockarray[75][1] = 3;
blockarray[75][33] = 3;
blockarray[75][34] = 3;
blockarray[75][38] = 3;
blockarray[75][40] = 3;
blockarray[75][48] = 3;
blockarray[76][1] = 3;
blockarray[76][33] = 3;
blockarray[76][34] = 3;
blockarray[76][38] = 3;
blockarray[76][39] = 3;
blockarray[76][40] = 3;
blockarray[76][48] = 3;
blockarray[77][1] = 3;
blockarray[77][38] = 3;
blockarray[77][40] = 3;
blockarray[77][48] = 3;
blockarray[78][1] = 3;
blockarray[78][38] = 3;
blockarray[78][39] = 3;
blockarray[78][40] = 3;
blockarray[78][48] = 3;
blockarray[79][1] = 3;
blockarray[79][32] = 3;
blockarray[79][33] = 3;
blockarray[79][34] = 3;
blockarray[79][35] = 3;
blockarray[79][38] = 3;
blockarray[79][40] = 3;
blockarray[79][48] = 3;
blockarray[80][1] = 3;
blockarray[80][32] = 3;
blockarray[80][35] = 3;
blockarray[80][38] = 3;
blockarray[80][39] = 3;
blockarray[80][40] = 3;
blockarray[80][48] = 3;
blockarray[81][1] = 3;
blockarray[81][32] = 3;
blockarray[81][35] = 3;
blockarray[81][48] = 3;
blockarray[82][1] = 3;
blockarray[82][32] = 3;
blockarray[82][35] = 3;
blockarray[82][48] = 3;
blockarray[83][1] = 3;
blockarray[83][32] = 3;
blockarray[83][35] = 3;
blockarray[83][48] = 3;
blockarray[84][1] = 3;
blockarray[84][32] = 3;
blockarray[84][35] = 3;
blockarray[84][48] = 3;
blockarray[85][1] = 3;
blockarray[85][32] = 3;
blockarray[85][35] = 3;
blockarray[85][48] = 3;
blockarray[86][1] = 3;
blockarray[86][32] = 3;
blockarray[86][35] = 3;
blockarray[86][48] = 3;
blockarray[87][1] = 3;
blockarray[87][32] = 3;
blockarray[87][35] = 3;
blockarray[87][48] = 3;
blockarray[88][1] = 3;
blockarray[88][32] = 3;
blockarray[88][35] = 3;
blockarray[88][48] = 3;
blockarray[89][1] = 3;
blockarray[89][32] = 3;
blockarray[89][35] = 3;
blockarray[89][48] = 3;
blockarray[90][1] = 3;
blockarray[90][32] = 3;
blockarray[90][33] = 3;
blockarray[90][34] = 3;
blockarray[90][35] = 3;
blockarray[90][48] = 3;
blockarray[91][1] = 3;
blockarray[91][48] = 3;
blockarray[92][1] = 3;
blockarray[92][48] = 3;
blockarray[93][1] = 3;
blockarray[93][48] = 3;
blockarray[94][1] = 3;
blockarray[94][48] = 3;
blockarray[95][1] = 3;
blockarray[95][32] = 3;
blockarray[95][33] = 3;
blockarray[95][34] = 3;
blockarray[95][35] = 3;
blockarray[95][48] = 3;
blockarray[96][1] = 3;
blockarray[96][32] = 3;
blockarray[96][35] = 3;
blockarray[96][48] = 3;
blockarray[97][1] = 3;
blockarray[97][32] = 3;
blockarray[97][35] = 3;
blockarray[97][48] = 3;
blockarray[98][1] = 3;
blockarray[98][32] = 3;
blockarray[98][35] = 3;
blockarray[98][48] = 3;
blockarray[99][1] = 3;
blockarray[99][32] = 3;
blockarray[99][35] = 3;
blockarray[99][48] = 3;
blockarray[100][1] = 3;
blockarray[100][32] = 3;
blockarray[100][35] = 3;
blockarray[100][48] = 3;
blockarray[101][1] = 3;
blockarray[101][32] = 3;
blockarray[101][35] = 3;
blockarray[101][48] = 3;
blockarray[102][1] = 3;
blockarray[102][32] = 3;
blockarray[102][35] = 3;
blockarray[102][48] = 3;
blockarray[103][1] = 3;
blockarray[103][32] = 3;
blockarray[103][35] = 3;
blockarray[103][48] = 3;
blockarray[104][1] = 3;
blockarray[104][32] = 3;
blockarray[104][35] = 3;
blockarray[104][48] = 3;
blockarray[105][1] = 3;
blockarray[105][32] = 3;
blockarray[105][35] = 3;
blockarray[105][48] = 3;
blockarray[106][1] = 3;
blockarray[106][32] = 3;
blockarray[106][35] = 3;
blockarray[106][48] = 3;
blockarray[107][1] = 3;
blockarray[107][32] = 3;
blockarray[107][33] = 3;
blockarray[107][34] = 3;
blockarray[107][35] = 3;
blockarray[107][48] = 3;
blockarray[108][1] = 3;
blockarray[108][48] = 3;
blockarray[109][1] = 3;
blockarray[109][48] = 3;
blockarray[110][1] = 3;
blockarray[110][48] = 3;
blockarray[111][1] = 3;
blockarray[111][48] = 3;
blockarray[112][1] = 3;
blockarray[112][48] = 3;
blockarray[113][1] = 3;
blockarray[113][48] = 3;
blockarray[114][1] = 3;
blockarray[114][22] = 3;
blockarray[114][23] = 3;
blockarray[114][32] = 3;
blockarray[114][33] = 3;
blockarray[114][34] = 3;
blockarray[114][35] = 3;
blockarray[114][48] = 3;
blockarray[115][1] = 3;
blockarray[115][22] = 3;
blockarray[115][23] = 3;
blockarray[115][32] = 3;
blockarray[115][35] = 3;
blockarray[115][48] = 3;
blockarray[116][1] = 3;
blockarray[116][32] = 3;
blockarray[116][35] = 3;
blockarray[116][48] = 3;
blockarray[117][1] = 3;
blockarray[117][15] = 3;
blockarray[117][16] = 3;
blockarray[117][32] = 3;
blockarray[117][35] = 3;
blockarray[117][48] = 3;
blockarray[118][1] = 3;
blockarray[118][15] = 3;
blockarray[118][16] = 3;
blockarray[118][27] = 3;
blockarray[118][32] = 3;
blockarray[118][35] = 3;
blockarray[118][48] = 3;
blockarray[119][1] = 3;
blockarray[119][26] = 3;
blockarray[119][27] = 3;
blockarray[119][32] = 3;
blockarray[119][35] = 3;
blockarray[119][48] = 3;
blockarray[120][1] = 3;
blockarray[120][27] = 3;
blockarray[120][32] = 3;
blockarray[120][35] = 3;
blockarray[120][48] = 3;
blockarray[121][1] = 3;
blockarray[121][27] = 3;
blockarray[121][32] = 3;
blockarray[121][35] = 3;
blockarray[121][48] = 3;
blockarray[122][1] = 3;
blockarray[122][27] = 3;
blockarray[122][32] = 3;
blockarray[122][35] = 3;
blockarray[122][48] = 3;
blockarray[123][1] = 3;
blockarray[123][32] = 3;
blockarray[123][35] = 3;
blockarray[123][48] = 3;
blockarray[124][1] = 3;
blockarray[124][21] = 3;
blockarray[124][22] = 3;
blockarray[124][32] = 3;
blockarray[124][35] = 3;
blockarray[124][48] = 3;
blockarray[125][1] = 3;
blockarray[125][21] = 3;
blockarray[125][22] = 3;
blockarray[125][32] = 3;
blockarray[125][35] = 3;
blockarray[125][48] = 3;
blockarray[126][1] = 3;
blockarray[126][32] = 3;
blockarray[126][33] = 3;
blockarray[126][34] = 3;
blockarray[126][35] = 3;
blockarray[126][48] = 3;
blockarray[127][1] = 3;
blockarray[127][48] = 3;
blockarray[128][1] = 3;
blockarray[128][48] = 3;
blockarray[129][1] = 3;
blockarray[129][34] = 3;
blockarray[129][35] = 3;
blockarray[129][43] = 3;
blockarray[129][44] = 3;
blockarray[129][48] = 3;
blockarray[130][1] = 3;
blockarray[130][34] = 3;
blockarray[130][35] = 3;
blockarray[130][43] = 3;
blockarray[130][44] = 3;
blockarray[130][48] = 3;
blockarray[131][1] = 3;
blockarray[131][48] = 3;
blockarray[132][1] = 3;
blockarray[132][48] = 3;
blockarray[133][1] = 3;
blockarray[133][48] = 3;
blockarray[134][1] = 3;
blockarray[134][39] = 3;
blockarray[134][40] = 3;
blockarray[134][48] = 3;
blockarray[135][1] = 3;
blockarray[135][39] = 3;
blockarray[135][40] = 3;
blockarray[135][48] = 3;
blockarray[136][1] = 3;
blockarray[136][48] = 3;
blockarray[137][1] = 3;
blockarray[137][32] = 3;
blockarray[137][33] = 3;
blockarray[137][34] = 3;
blockarray[137][35] = 3;
blockarray[137][48] = 3;
blockarray[138][1] = 3;
blockarray[138][32] = 3;
blockarray[138][35] = 3;
blockarray[138][48] = 3;
blockarray[139][1] = 3;
blockarray[139][32] = 3;
blockarray[139][35] = 3;
blockarray[139][48] = 3;
blockarray[140][1] = 3;
blockarray[140][32] = 3;
blockarray[140][35] = 3;
blockarray[140][48] = 3;
blockarray[141][1] = 3;
blockarray[141][32] = 3;
blockarray[141][35] = 3;
blockarray[141][48] = 3;
blockarray[142][1] = 3;
blockarray[142][32] = 3;
blockarray[142][35] = 3;
blockarray[142][48] = 3;
blockarray[143][1] = 3;
blockarray[143][32] = 3;
blockarray[143][35] = 3;
blockarray[143][48] = 3;
blockarray[144][1] = 3;
blockarray[144][32] = 3;
blockarray[144][35] = 3;
blockarray[144][48] = 3;
blockarray[145][1] = 3;
blockarray[145][32] = 3;
blockarray[145][35] = 3;
blockarray[145][48] = 3;
blockarray[146][1] = 3;
blockarray[146][32] = 3;
blockarray[146][33] = 3;
blockarray[146][34] = 3;
blockarray[146][35] = 3;
blockarray[146][48] = 3;
blockarray[147][1] = 3;
blockarray[147][48] = 3;
blockarray[148][0] = 3;
blockarray[148][1] = 3;
blockarray[148][2] = 3;
blockarray[148][3] = 3;
blockarray[148][4] = 3;
blockarray[148][5] = 3;
blockarray[148][6] = 3;
blockarray[148][7] = 3;
blockarray[148][8] = 3;
blockarray[148][9] = 3;
blockarray[148][10] = 3;
blockarray[148][11] = 3;
blockarray[148][12] = 3;
blockarray[148][13] = 3;
blockarray[148][14] = 3;
blockarray[148][15] = 3;
blockarray[148][16] = 3;
blockarray[148][17] = 3;
blockarray[148][18] = 3;
blockarray[148][19] = 3;
blockarray[148][20] = 3;
blockarray[148][21] = 3;
blockarray[148][22] = 3;
blockarray[148][23] = 3;
blockarray[148][24] = 3;
blockarray[148][25] = 3;
blockarray[148][26] = 3;
blockarray[148][27] = 3;
blockarray[148][28] = 3;
blockarray[148][29] = 3;
blockarray[148][30] = 3;
blockarray[148][31] = 3;
blockarray[148][32] = 3;
blockarray[148][33] = 3;
blockarray[148][34] = 3;
blockarray[148][35] = 3;
blockarray[148][36] = 3;
blockarray[148][37] = 3;
blockarray[148][38] = 3;
blockarray[148][39] = 3;
blockarray[148][40] = 3;
blockarray[148][41] = 3;
blockarray[148][42] = 3;
blockarray[148][43] = 3;
blockarray[148][44] = 3;
blockarray[148][45] = 3;
blockarray[148][46] = 3;
blockarray[148][47] = 3;
blockarray[148][48] = 3;
blockarray[148][49] = 3;
blockarray[149][1] = 3;
blockarray[149][48] = 3;
             
             
            AddMob(50,50);

            AddMob(200, 50);

        }
        /*
        public int[] toArray()
        {
            int index = 0;
            int[] temp = new int[this.levelheight * this.levelwidth];

            for (int i = 0; i < this.levelwidth; i++)
            {
                for (int j = 0; j < this.levelwidth; j++)
                {

                    //if (blockarray[j,i].blockType == BlockType.Air){
                    if (blockarray[j,i]==0)
                        temp[index] = 0;

                    }
                    else{
                        temp[index] = 1;
                    }



                   

                }


            }

            return temp;

        }
         * */

        public int AddPlayer()
        {

            PlayerObject temp = new PlayerObject(new PlayerController());

            playerArray.Add(temp);

            return temp.id;


        }

        public void AddMob(float x, float y)
        {
            MobObject temp = new MobObject(x, y);

            playerArray.Add(temp);

        }

        public void Update(float dt)
        {

            if (this.locked)
            {

                Debug.WriteLine("locked");

            }
            else
            {
                this.locked = true;

                foreach (PointObject p in pointArray)
                {
                    if (p.life > 0)
                    {
                        p.Update(dt);
                    }


                }



                //Debug.WriteLine(" P : " + testPoint.currentstate.x_position + "   " + testPoint.currentstate.y_position);

                index2 tempindex;
                index2 tempindex0;
                index2 tempindexi;

                //Debug.WriteLine("xvel : " + singleplayer.currentstate.x_velocity + " yvel : " + singleplayer.currentstate.y_velocity);

                //see iff the desired position is valid

                foreach (PhysicsObject singleplayer in playerArray)
                {
                    singleplayer.Update(dt);
                }


                foreach (PhysicsObject singleplayer in playerArray)
                {
                    //singleplayer.Update(dt);
                    tempindex = getBlockIndex(singleplayer.desiredstate.x_position, singleplayer.desiredstate.y_position);

                    if (tempindex.x <= 0 || tempindex.y <= 0 || tempindex.x >= levelwidth - 1 || tempindex.y >= levelheight - 1)
                    {
                        //object is out of range

                    }
                    else
                    {


                        if (singleplayer.desiredstate.x_velocity > 0)
                        {
                            tempindex = getBlockIndex(singleplayer.desiredstate.x_position + singleplayer.halfwidth, singleplayer.desiredstate.y_position);
                            //moving right, check right face
                            if (blockarray[tempindex.x][tempindex.y] > 0)
                            {
                                //left edge of right block
                                singleplayer.desiredstate.x_position = ((tempindex.x - 1) * 16 + halfblock);
                                singleplayer.desiredstate.x_velocity = singleplayer.collisioncoefficient * -1 * singleplayer.desiredstate.x_velocity;

                            }

                        }
                        else if (singleplayer.desiredstate.x_velocity < 0)
                        {
                            tempindex = getBlockIndex(singleplayer.desiredstate.x_position - singleplayer.halfwidth, singleplayer.desiredstate.y_position);
                            //moving left, check left face
                            if (blockarray[tempindex.x][tempindex.y] > 0)
                            {
                                //right edge of left block
                                singleplayer.desiredstate.x_position = (tempindex.x + 1) * 16 + halfblock;
                                singleplayer.desiredstate.x_velocity = singleplayer.collisioncoefficient * -1 * singleplayer.desiredstate.x_velocity;
                            }

                        }

                        if (singleplayer.desiredstate.y_velocity >= 0)
                        {
                            tempindex = getBlockIndex(singleplayer.desiredstate.x_position, singleplayer.desiredstate.y_position + singleplayer.halfheight);
                            //moving down, check bottom face
                            if (blockarray[tempindex.x][tempindex.y] > 0)
                            {
                                //top edge of bottom block
                                singleplayer.desiredstate.y_position = ((tempindex.y - 1) * 16)+(16-singleplayer.halfheight);
                                singleplayer.desiredstate.y_velocity = 0;

                            }

                        }
                        else if (singleplayer.desiredstate.y_velocity < 0)
                        {
                            tempindex = getBlockIndex(singleplayer.desiredstate.x_position, singleplayer.desiredstate.y_position - singleplayer.halfheight);
                            //moving up, check top face
                            if (blockarray[tempindex.x][tempindex.y] > 0)
                            {
                                //align to bottom edge of top block

                                //hitting head on block, if still holding jump breaks the block and slows down
                                if (singleplayer.jumpcounter > 2)
                                {
                                    changeBlock(tempindex.x, tempindex.y, 0);
                                    singleplayer.jumpcounter = 0;
                                    singleplayer.desiredstate.y_velocity = singleplayer.desiredstate.y_velocity / 4;

                                }
                                else
                                {
                                    singleplayer.desiredstate.y_position = ((tempindex.y + 1) * 16 + singleplayer.halfheight);
                                    singleplayer.desiredstate.y_velocity = -1;
                                }
                            }

                        }

                        
                        foreach (PhysicsObject compareplayer in playerArray)
                        {

                            if ((singleplayer.id == compareplayer.id)||(compareplayer.invultimer>0))
                            {
                                //skip self compares

                            }
                            else
                            {
                                //Debug.WriteLine(singleplayer.desiredstate.x_position + "    " + compareplayer.desiredstate.x_position);
                                //if ((singleplayer.desiredstate.x_position < compareplayer.desiredstate.x_position - 14) || (singleplayer.desiredstate.x_position > compareplayer.desiredstate.x_position + 14) || ((singleplayer.desiredstate.y_position + singleplayer.halfheight) > (compareplayer.desiredstate.y_position + compareplayer.halfheight - 2)) || (singleplayer.desiredstate.y_position < compareplayer.desiredstate.y_position - (singleplayer.halfheight + compareplayer.halfheight)))
                                if ((singleplayer.desiredstate.x_position < compareplayer.desiredstate.x_position - 14) || (singleplayer.desiredstate.x_position > compareplayer.desiredstate.x_position + 14) || ((singleplayer.desiredstate.y_position+singleplayer.halfheight)  < (compareplayer.desiredstate.y_position - compareplayer.halfheight)) || (singleplayer.desiredstate.y_position-singleplayer.halfheight > compareplayer.desiredstate.y_position + compareplayer.halfheight))
                                {

                                }
                                else if (((singleplayer.desiredstate.y_position + singleplayer.halfheight) < (compareplayer.desiredstate.y_position -compareplayer.halfheight)) || ((singleplayer.desiredstate.y_position+singleplayer.halfheight) > compareplayer.desiredstate.y_position ))
                                {

                                    if (singleplayer.type == "movingshell")
                                    {
                                        compareplayer.life--;
                                        compareplayer.invultimer = 5;

                                    }
                                    else if ((singleplayer.type != "player") && (compareplayer.type != "player"))
                                    {
                                        //two mobs collide, just turn
                                        singleplayer.desiredstate.x_velocity = -singleplayer.desiredstate.x_velocity;
                                        //compareplayer.desiredstate.x_velocity = -compareplayer.desiredstate.x_velocity;

                                    }
                                    else if ((singleplayer.type == "player") && (compareplayer.type == "player"))
                                    {
                                        //two players collide, dont really care

                                    }
                                    else if ((singleplayer.type == "player") && (compareplayer.type == "shell"))
                                    {
                                        compareplayer.life--;
                                        compareplayer.invultimer = 3;
                                        compareplayer.RegisterHit(singleplayer);

                                    }
                                    else if (compareplayer.type == "player")
                                    {
                                        //player getting hit by a mob
                                        //singleplayer.desiredstate.x_velocity = -singleplayer.desiredstate.x_velocity;
                                        compareplayer.life--;
                                        compareplayer.invultimer = 5;

                                    }

                                }
                                else
                                {

                                    //Debug.WriteLine("x1 : " + singleplayer.desiredstate.x_position + " y1:  " + singleplayer.desiredstate.y_position + "x2 : " + compareplayer.desiredstate.x_position + " y2:  " + compareplayer.desiredstate.y_position);

                                    //jumping on another player or mobs head
                                    if (singleplayer.type == "player")
                                    {
                                        compareplayer.life--;
                                        compareplayer.RegisterHit(singleplayer);

                                        singleplayer.desiredstate.y_velocity = -200;
                                        singleplayer.desiredstate.y_position = compareplayer.desiredstate.y_position - (singleplayer.halfheight + compareplayer.halfheight);
                                        //compareplayer.desiredstate.y_velocity = 5;
                                    }
                                    //compareplayer.invultimer = 3;


                                }
                                
                            }


                        }


                

                    }
                }

                foreach (PhysicsObject singleplayer in playerArray)
                {


                    singleplayer.currentstate = singleplayer.desiredstate;
                    singleplayer.desiredstate = new PhysicalState();


                }

                foreach (PointObject p in pointArray)
                {

                    if (p.life > 0)
                    {


                        tempindex = getBlockIndex(p.desiredstate.x_position, p.desiredstate.y_position);
                        tempindexi = getBlockIndex(((p.desiredstate.x_position + p.currentstate.x_position) / 2), ((p.desiredstate.y_position + p.currentstate.y_position) / 2));


                        if (tempindex.x <= 0 || tempindex.y <= 0 || tempindex.x >= levelwidth - 1 || tempindex.y >= levelheight - 1)
                        {
                            //object is out of range

                        }
                        else
                        {
                            /*
                            if (blockarray[tempindexi.x][tempindexi.y] > 0)
                            {
                                tempindex0 = getBlockIndex(p.currentstate.x_position, p.currentstate.y_position);

                            

                            
                                if (blockarray[tempindex0.x][tempindexi.y] > 0)
                                {
                                    //bouncing off y axis
                                    p.desiredstate.y_velocity = -p.desiredstate.y_velocity;

                                }
                                if (blockarray[tempindexi.x][tempindex0.y] > 0)
                                {
                                    //bouncing off x axis
                                    p.desiredstate.x_velocity = -p.desiredstate.x_velocity;

                                }

                                blockarray[tempindexi.x][tempindexi.y]--;
                                p.life--;
                                updatedblocks.Add(new BlockUpdate(tempindexi.x, tempindexi.y, blockarray[tempindexi.x][tempindexi.y]));

                            

                            }
                            else 
                             * 
                             * gonna slow down fireballs, dont need intermediate check
                                */

                            if (blockarray[tempindex.x][tempindex.y] > 0)
                            {
                                tempindex0 = getBlockIndex(p.currentstate.x_position, p.currentstate.y_position);

                                //fireballs will only bounce off the floor - moving down and 

                                if (p.desiredstate.y_velocity >= 0)
                                {

                                    //moving down, capable of bouncing


                                    if (blockarray[tempindex0.x][tempindex.y] > 0)
                                    {
                                        //bouncing off y axis
                                        p.desiredstate.y_velocity = -p.desiredstate.y_velocity;

                                    }
                                    else if (blockarray[tempindex.x][tempindex0.y] > 0)
                                    {
                                        //hitting a wall, not bouncing
                                        p.desiredstate.x_velocity = -p.desiredstate.x_velocity;
                                        p.life--;

                                    }


                                }
                                else
                                {

                                    //moving up, just explode
                                    p.life--;

                                }



                                //blockarray[tempindex.x][tempindex.y]--;
                                //p.life--;
                                //updatedblocks.Add(new BlockUpdate(tempindex.x, tempindex.y, blockarray[tempindex.x][tempindex.y]));

                            }
                            else
                            {

                                if (p.frame >= 1)
                                {

                                    foreach (PhysicsObject po in playerArray)
                                    {

                                        if ((p.desiredstate.x_position < po.currentstate.x_position - po.halfwidth) || (p.desiredstate.x_position > po.currentstate.x_position + po.halfwidth) || (p.desiredstate.y_position < po.currentstate.y_position - po.halfheight) || (p.desiredstate.y_position > po.currentstate.y_position + po.halfheight))
                                        {
                                            //not inside a player 

                                        }
                                        else
                                        {

                                            p.life--;
                                            po.life--;
                                            po.invultimer = 3;

                                            /*
                                            tempdouble = calcDistance(po.currentstate.x_position, po.currentstate.y_position, p.desiredstate.x_position, p.desiredstate.y_position);
                                            tempfloat = (float)(1 / tempdouble);

                                            tempangle = Math.Atan2(p.desiredstate.y_position - po.currentstate.y_position, p.desiredstate.x_position - po.currentstate.x_position);

                                            Debug.WriteLine("this : " + Math.Cos(tempangle) / tempdouble);
                                            po.x_force += (float) (500 * (Math.Cos(tempangle) / tempdouble));
                                            po.y_force += (float) (500 * (Math.Sin(tempangle) / tempdouble));*/


                                            //po.x_force += (float) (600 / Math.Pow(po.currentstate.x_position - p.desiredstate.x_position,2));
                                            //po.y_force += (float) (600 / Math.Pow(po.currentstate.y_position - p.desiredstate.y_position, 2));

                                        }

                                    }

                                }
                            }
                            //projectile has not hit anything yet
                            if (p.life > 0)
                            {
                                //p.frame++;
                                p.currentstate = p.desiredstate;
                                p.desiredstate = new PhysicalState();
                            }

                            /*------ fireballs no longer exploding
                            else
                            {
                                //projectile has hit something and explodes, forces are generated for nearby objects
                                double tempdist;
                                double tempang;

                                foreach (PlayerObject po in playerArray)
                                {

                                    tempdist = calcDistance(po.currentstate.x_position, po.currentstate.y_position, p.desiredstate.x_position,p.desiredstate.y_position);
                                
                                    if (tempdist < 60){
                                
                                        tempang = Math.Atan2(po.currentstate.y_position - p.desiredstate.y_position, po.currentstate.x_position - p.desiredstate.x_position);
                                
                                        tempdist = 60 - tempdist;

                                        //force from explosion is estimated by a spring force, F = kx
                                        po.x_force += (float)(200 * tempdist * Math.Cos(tempang));
                                        po.y_force += (float)(200 * tempdist * Math.Sin(tempang));

                                        po.life--;

                                    Debug.WriteLine(po.x_force + "  " + po.y_force + "  " + tempdist);

                                    }
                                

                                }

                            
                            }

                            */

                        }
                    }
                }

                this.locked = false;
            }

            

        }

        public void changeBlock(int xindex, int yindex, int newvalue)
        {



            blockarray[xindex][yindex] = newvalue;
            
            updatedblocks.Add(new BlockUpdate(xindex, yindex, newvalue));

        }

        public vector2 beamProjection(float startingx, float startingy, double angle, int maxdistance)
        {
            int step = 8;
            index2 temp = getBlockIndex(startingx, startingy);
            float incrementx = (float)(Math.Cos(angle) * step);
            float incrementy = (float)(Math.Sin(angle) * step);
            double tempdouble;
            double tempdouble2;
            startingx += 2*incrementx;
            startingy += 2*incrementy;


            for(int i = step; i<maxdistance; i=i+step){


                startingx += incrementx;
                startingy += incrementy;
                temp = getBlockIndex(startingx, startingy);

                if (blockarray[temp.x][temp.y] > 0)
                {
                    break;

                }
                else
                {

                    foreach (PlayerObject po in playerArray)
                    {

                        if (po.invul)
                        {
                            //player already hit dont hit again

                        }
                        else
                        {
                            tempdouble = calcDistance(po.currentstate.x_position, po.currentstate.y_position-8, startingx, startingy);
                            tempdouble2 = calcDistance(po.currentstate.x_position, po.currentstate.y_position+8, startingx, startingy);


                            if (tempdouble <= 10)
                            {
                                po.life--;
                                po.invul = true;

                            }
                            else if (tempdouble2 <= 10)
                            {
                                po.life--;
                                po.invul = true;

                            }

                        
                        }
                    }
                }


            }

            return (new vector2(startingx, startingy));

        }

        public double calcDistance(float x1, float y1, float x2, float y2)
        {

            return Math.Sqrt(Math.Pow(x2-x1,2) + Math.Pow(y2-y1,2));

            
        }

        public vector2 isCollide(float px, float py, float vx, float vy)
        {
            vector2 temp = new vector2();
            index2 blockindex = getBlockIndex(px, py);

            if (blockarray[blockindex.x][blockindex.y] > 0)
            {
                if (vx < 0){

                    temp.x = ((blockindex.x+1)*16)-px;

                }
                else if (vx > 0){

                    temp.x = blockindex.x*16-px;

                }

                if (vy < 0)
                {
                    temp.y = (blockindex.y + 1) * 16 - py;


                }
                else if (vy > 0)
                {
                    temp.y = (blockindex.y * 16) - py;

                }


            }

            return temp;

        }

        public bool isBlockCollide(float x, float y)
        {
            return false;



        }
        public void checkCollision(PhysicsObject p)
        {



        }

        public void addBlock(float x, float y)
        {
            index2 tempindex;
            tempindex = getBlockIndex(x, y);

            if ((tempindex.x>0) && (tempindex.y>0) && (tempindex.x < levelwidth) && (tempindex.y<levelheight)){

                if (blockarray[tempindex.x][tempindex.y] < 1)
                {

                    blockarray[tempindex.x][tempindex.y] = 3;
                    updatedblocks.Add(new BlockUpdate(tempindex.x, tempindex.y, 3));
                }
                else
                {

                    blockarray[tempindex.x][tempindex.y] = 0;
                    updatedblocks.Add(new BlockUpdate(tempindex.x, tempindex.y, 0));

                }

            }

        }



        public index2 getBlockIndex(float x, float y)
        {
            index2 temp = new index2();

            temp.x = (int)(Math.Floor(x / 16));
            temp.y = (int)(Math.Floor(y / 16));


            return temp;
        }

        

    }

    public class BlockUpdate{

        public int x;
        public int y;
        public int value;

        public BlockUpdate(int x, int y, int value){

            this.x = x;
            this.y = y;
            this.value = value;

        }

    }
    

    public class vector2
    {
        public float x;
        public float y;


        public vector2(float xx, float yy)
        {
            this.x = xx;
            this.y = yy;

        }

        public vector2()
        {
            this.x = 0f;
            this.y = 0f;

        }


    }

    public class index2
    {

        public int x;
        public int y;

        public index2()
        {
            

        }


    }


}