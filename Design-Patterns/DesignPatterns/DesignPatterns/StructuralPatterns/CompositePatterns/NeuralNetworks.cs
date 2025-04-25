using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.CompositePatterns
{

    public static class ExtensionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> Self, IEnumerable<Neuron> Other)
        {
            if (ReferenceEquals(Self, Other)) return;

            if (Self is null || Other is null) return;

            foreach(var self in Self)
            {
                foreach(var other in Other)
                {
                    self.Out.Add(other);
                    other.In.Add(self);
                }
            }
        }

        public static int SumComposite(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }

    // What we want is the connection from this neuron to other neurons
    // And also want to track the connections which are incoming
    // So, we have two sets of connections, connections comming in and connection going out.
    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;

        public List<Neuron> In, Out;

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;  // we yield return ourselves as the one and only element which is actually providing an enumerator. 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // What we are going to do is to add neuron layers
    // Neuron layers is simply a collection of neurons
    // And we also want to it be connectable to things
    public class NeuronLayer : Collection<Neuron>
    {

    }


}
 