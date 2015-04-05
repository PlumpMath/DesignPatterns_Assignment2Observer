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
    class BadGuy:IObserver<LOTRSpecies>
    {
        private IDisposable unsubscriber;
        private string _name;

        public BadGuy(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public virtual void Subscribe(IObservable<LOTRSpecies> provider)
        {
            if(provider != null)
            {
                unsubscriber = provider.Subscribe(this);
            }
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("{0} has been defeated.",this._name);
            this.Unsubsribe();
            
        }

        public void defeated()
        {
            this.OnCompleted();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: somthing went wrong.");
        }

        public virtual void OnNext(LOTRSpecies value)
        {
            Console.WriteLine("{2}: I know about {0} {1}.", value.numberOf, value.Species, this._name);
        }

        public virtual void Unsubsribe()
        {
            unsubscriber.Dispose();
        }
    }
}
