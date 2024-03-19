using Codecool.Quest.Models.Actors;
using System.IO;
using System.Threading;


namespace Codecool.Quest.Models
{
    public class MapLoader
    {

        //public static string level { get; set; } = @"\Resources\map.txt";

        public static GameMap LoadMap(string level)
        {
            string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string level = @"\Resources\map.txt";
            StreamReader stream = new StreamReader(dir + level);
            string firstline = stream.ReadLine();
            string[] firstline_split = firstline.Split(' ');

            int width = int.Parse(firstline_split[0]);
            int height = int.Parse(firstline_split[1]);

            GameMap map = new GameMap(width, height, CellType.EMPTY);

            for (int y = 0; y < height; y++)
            {
                string line = stream.ReadLine();

                for (int x = 0; x < width; x++)
                {
                    if (x < line.Length)
                    {
                        Cell cell = map.GetCell(x, y);

                        switch (line[x])
                        {
                            //UEH DSA
                            case 'D':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "DSA-D");
                                break;
                            case 'S':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "DSA-S");
                                break;
                            case 'A':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "DSA-A");
                                break;
                            //Thang Máy
                            case '=':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "elevator1");
                                break;
                            case '~':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "elevator2");
                                break;
                            //Lễ Tân UEH
                            case '6':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "letan1");
                                break;
                            case '7':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "letan2");
                                break;
                            case 'w':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "letan3");
                                break;
                            case 'h':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "letan4");
                                break;
                            case 'r':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "letan5");
                                break;
                            case 'b':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "letan6");
                                break;
                            //2 trụ B1
                            case 'g':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "tru1");
                                break;
                            case 'j':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "tru2");
                                break;
                            case '%':
                                cell.CellType = CellType.WALL;
                                new Item(cell, "plant");
                                break;
                            //englishzone
                            case '/':
                                cell.CellType = CellType.WIN;
                                new Environment(cell, "stairs");
                                break;
                            case 'p':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "ez4");
                                break;
                            case 'a':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "ez5");
                                break;
                            case 'z':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "ez6");
                                break;
                            case '1':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "ez7");
                                break;
                            case '2':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "ez8");
                                break;
                            //englishzone-char
                            case '[':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "E");
                                break;
                            case 'i':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "N");
                                break;
                            case 'y':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "G");
                                break;
                            case 'f':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "L");
                                break;
                            case 'x':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "I");
                                break;
                            case 'v':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "S");
                                break;
                            case 'n':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "H");
                                break;
                            case 'm':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "Z");
                                break;
                            case '3':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "O");
                                break;
                            case '>':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "U");
                                break;
                            //ueh-cơ sở N - N1
                            case '<':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "n1");
                                break;
                            //ueh - cơ sở N - Vòi nước
                            case 'o':
                                cell.CellType = CellType.WALL;
                                new Item(cell, "n2");
                                break;

                            //csN - khuôn viên N2
                            /*
                            case '/':
                                cell.CellType = CellType.FLOOR;
                                new Environment(cell, "n4");
                                break;
                            */
                            //csA - xe
                            case '$':
                                cell.CellType = CellType.WALL;
                                new Item(cell, "car");
                                break;
                            case ' ':
                                {
                                    cell.CellType = CellType.EMPTY;
                                    break;
                                }
                            case '#':
                                {
                                    cell.CellType = CellType.WALL;
                                    break;
                                }
                            case '.':
                                {
                                    cell.CellType = CellType.FLOOR;
                                    break;
                                }

                            case '@':
                                {
                                    cell.CellType = CellType.FLOOR;
                                    map.Player = new Player(cell);
                                    break;
                                }
                            
                            case 'k':
                                cell.CellType = CellType.ITEM;
                                new Item(cell, "key");
                                break;
                            case 'd':
                                cell.CellType = CellType.DOOR;
                                new Item(cell, "door");
                                break;

                            case 'e':
                                cell.CellType = CellType.LEVEL2;
                                break;
                            case 't':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "tree");
                                break;
                            case '8':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "roof1");
                                break;
                            case '9':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "roof2");
                                break;
                            case '0':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "roof3");
                                break;
                            case '*':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "castle1");
                                break;
                            case '(':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "castle2");
                                break;
                            case ')':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "castle3");
                                break;
                            case '-':
                                cell.CellType = CellType.LEVEL3;
                                new Environment(cell, "castleDoor");
                                break;
                            case ',':
                                cell.CellType = CellType.CASTLE;
                                //new Environment(cell, "castleFloor");
                                break;
                            case 'c':
                                cell.CellType = CellType.WALL;
                                new Environment(cell, "castleWall");
                                break;

                            case '`':
                                cell.CellType = CellType.FLOOR;
                                new Environment(cell, "king");
                                break;
                        }
                    }
                }
            }
            return map;
        }
    }
}