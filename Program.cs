using System;
using System.Collections.Generic;

namespace Pylek
{

    public enum Type { LargeTree, Tree, Bush } // czy to wszystkie typy?

    public interface Plant
    {
        void Display(int positionX, int positionY);
    }

    public class LargeTree : Plant
    {
        string Texture { get; set; }
        public LargeTree(string type)
        {
            Texture=type;
        }


        public void Display(int x, int y)
        {
            Console.WriteLine($"Duże drzewo (plik \"{Texture}\") znajduje się na pozycji {x},{y}\n");
        }
    }
    public class Tree : Plant
    {
        string Texture { get; set; }
        public Tree(string type)
        {
            Texture = type;
        }
        


        public void Display(int x, int y)
        {
            Console.WriteLine($"Normalne drzewo (plik \"{Texture}\") znajduje się na pozycji {x},{y}\n");
        }
    }
    public class Bush : Plant
    {
        string Texture { get; set; }
        public Bush(string type)
        {
            Texture=type;
        }

        public void Display(int x, int y)
        {
            Console.WriteLine($"Krzak (plik \"{Texture}\") znajduje się na pozycji {x},{y}\n");
        }
    }

    

    public class PlantFactory
    {
        private Dictionary<Type, Plant> Plants = new Dictionary<Type, Plant>();

        public Plant GetPlant(Type type)
        {
            Plant plant;
            

            if (Plants.ContainsKey(type))
            {
                Console.WriteLine("Wykorzystuję istniejący obiekt");
                return Plants[type];
                
            }
            else
            {
                switch (type)
                {
                    case Type.LargeTree:
                        plant = new LargeTree("large_tree.png");
                        break;

                    case Type.Tree:
                        plant = new Tree("tree.png");
                        break;

                    default:
                        plant = new Bush("bush.png");
                        break;
                }
               
                Plants.Add(type, plant);
                Console.WriteLine("Tworzę nowy obiekt typu {0}", type);
            }
            return plant;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var factory = new PlantFactory();



            var plant = factory.GetPlant(Type.Tree);
            plant.Display(0, 0);
            plant = factory.GetPlant(Type.LargeTree);
            plant.Display(0, 7);
            plant = factory.GetPlant(Type.Tree);
            plant.Display(3, 16);
            plant = factory.GetPlant(Type.Bush);
            plant.Display(10, 9);
            plant = factory.GetPlant(Type.Tree);
            plant.Display(7, 7);
            plant = factory.GetPlant(Type.LargeTree);
            plant.Display(20, 0);
            plant = factory.GetPlant(Type.Tree);
            plant.Display(3, 28);
            plant = factory.GetPlant(Type.Bush);
            plant.Display(1, 5);
            plant = factory.GetPlant(Type.Tree);
            plant.Display(8, 8);



        }
    }

}