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
    class EyeOfSauron :IObservable<LOTRSpecies>
    {
        private List<LOTRSpecies> listOfEnemies;
        private List<IObserver<LOTRSpecies>> listOfBadGuys;

        public EyeOfSauron()
        {
            listOfBadGuys = new List<IObserver<LOTRSpecies>>();
            listOfEnemies = new List<LOTRSpecies>();
        }

        public void setEnemies(params LOTRSpecies[] values)
        {
            int i = 0;
            listOfEnemies.Clear();
            for(i=0;i<values.Length;i++)
            {
                listOfEnemies.Add(values[i]);
                foreach(var observer in listOfBadGuys)
                {
                    observer.OnNext(values[i]);
                }
            }

            
        }

        public IDisposable Subscribe(IObserver<LOTRSpecies> observer)
        {
            if(!listOfBadGuys.Contains(observer))
            {
                listOfBadGuys.Add(observer);
            }
            return new Unsubscriber(listOfBadGuys, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<LOTRSpecies>> _observers;
            private IObserver<LOTRSpecies> _observer;

            public Unsubscriber(List<IObserver<LOTRSpecies>> observers, IObserver<LOTRSpecies> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if(_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }
    }
}
