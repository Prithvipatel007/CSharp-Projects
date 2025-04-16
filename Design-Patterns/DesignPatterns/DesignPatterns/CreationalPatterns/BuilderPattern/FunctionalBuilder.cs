using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.BuilderPattern
{
    public class FuncPerson
    {
        public string Name, Position;

    }

    public abstract class FunctionalBuilder<TSubject, TSelf> 
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(p => {
                action(p);
                return p;
            });

            return (TSelf)this;
        }

        public TSelf Do(Action<TSubject> action) => AddAction(action);

        public TSubject Build() => actions.Aggregate(new TSubject(), (p, f) => f(p));
    }

    public sealed class FuncPersonBuilder : FunctionalBuilder<Person, FuncPersonBuilder>
    {
        public FuncPersonBuilder Called(string name) => Do(p => p.Name = name);

    }


    // As this class is sealed, other classes cannot inherit from it.
    // If you want to extend it somehow, you dont have ability to use inheritance.
    // You do have ability to use extension methods instead, which is also going to work. 
    //public sealed class FuncPersonBuilder
    //{
    //    private readonly List<Func<FuncPerson, FuncPerson>> actions = new List<Func<FuncPerson, FuncPerson>>();

    //    private FuncPersonBuilder AddAction(Action<FuncPerson> action)
    //    {
    //        actions.Add(p => { 
    //            action(p); 
    //            return p; 
    //        });

    //        return this;
    //    }

    //    public FuncPersonBuilder Do(Action<FuncPerson> action) => AddAction(action);

    //    public FuncPersonBuilder Called(string name)
    //    {
    //        return AddAction(p => p.Name = name);
    //    }

    //    public FuncPerson Build() => actions.Aggregate(new FuncPerson(), (p, f) => f(p));
    //}

    // Extension methods
    public static class FuncPersonBuilderExtensions
    {
        public static FuncPersonBuilder WorkAs(this FuncPersonBuilder builder, string position) => builder.Do(p => p.Position = position);
    }


}
