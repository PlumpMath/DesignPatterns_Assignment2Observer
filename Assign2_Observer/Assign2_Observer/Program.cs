using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Created by: James Felts
 */

namespace Assign2_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            EyeOfSauron eye = new EyeOfSauron();

            BadGuy saruman = new BadGuy("Saruman");
            BadGuy witchKing = new BadGuy("Witch King");
            saruman.Subscribe(eye);
            witchKing.Subscribe(eye);

            eye.setEnemies(new LOTRSpecies(1, "Hobbit"), new LOTRSpecies(1, "elf"), new LOTRSpecies(2, "dwarves"));

            saruman.defeated();
            eye.setEnemies(new LOTRSpecies(4, "Hobbits"), new LOTRSpecies(2, "elves"), new LOTRSpecies(2, "dwarves"), new LOTRSpecies(100, "men"));

            Console.WriteLine("enter q to exit");
            while (Console.Read() != 'q') ;
        }
    }
}
