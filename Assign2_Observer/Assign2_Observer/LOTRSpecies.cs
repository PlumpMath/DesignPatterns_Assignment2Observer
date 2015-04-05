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
    class LOTRSpecies
    {
        private string _species;
        private int _numberOf;

        public LOTRSpecies(int num, string spec)
        {
            _species = spec;
            _numberOf = num;
        }

        public string Species
        {
            get { return _species; }
        }

        public int numberOf
        {
            get { return _numberOf; }
        }
    }
}
