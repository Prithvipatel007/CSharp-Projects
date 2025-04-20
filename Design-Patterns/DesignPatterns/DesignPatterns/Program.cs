using DesignPatterns.CreationalPatterns.BuilderPattern;
using DesignPatterns.CreationalPatterns.FactoryPattern;
using DesignPatterns.CreationalPatterns.PrototypePattern;
using DesignPatterns.DependencyInversionPrinciple;
using DesignPatterns.InterfaceSegregationPrinciple;
using DesignPatterns.LiskovSubstitutionPrinciple;
using DesignPatterns.OpenClosedPrinciple.Filter;
using DesignPatterns.OpenClosePrinciple;
using DesignPatterns.SingleRespPrinciple;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns.CreationalPatterns.BuilderPattern.FacetedBuilderPattern;
using static DesignPatterns.OpenClosedPrinciple.OpenClosedPrinciple;

namespace DesignPatterns
{
    internal class Program
    {
        /*
         * Switch to select the pattern to demonstrate
         */
        private static Pattern _Pattern = Pattern.PrototypeCodingExercise;

        #region Enum for Patterns
        public enum Pattern
        {
            SingleResponsibilityPrinciple,
            OpenClosedPrinciple,
            LiskovSubstitutionPrinciple,
            InterfaceSegregationPrinciple,
            DependencyInversionPrinciple,
            // Builder
            BuilderPattern,
            BuilderPatternWithRecursiveGenerics,
            StepwiseBuilderPattern,
            FunctionalBuilderPattern,
            FacetedBuilderPattern,
            BuilderPatternCodingExercise,
            // Factory
            SimpleFactoryMethod,
            AsyncFactoryMethod,
            ObjectTrackingAndBulkReplacementFactoryPattern,
            InnerFactory,
            AbstractFactoryPattern,
            AbstractFactoryWithOCPPattern,
            FactoryCodingExercise,
            // Prototype
            IClonableIsBadExample,
            CopyConstructorPrototypePattern,
            ExplicitDeepCopyPrototypePattern,
            PrototypeInheritance,
            SerializerPrototypePattern,
            PrototypeCodingExercise

        }
        #endregion

        #region Private Fields
        private static Action action = null;

        private static Dictionary<Pattern, Action> _PatternDict = new Dictionary<Pattern, Action>()
        {
            { Pattern.SingleResponsibilityPrinciple,                    SRP_Main.SingleResponsibilityPrinciple },
            { Pattern.OpenClosedPrinciple,                              OCP_Main.OpenClosedPrinciple },
            { Pattern.LiskovSubstitutionPrinciple,                      LSP_Main.LiskovSubstitutionPrinciple},
            { Pattern.InterfaceSegregationPrinciple,                    ISP_Main.InterfaceSegregationPrinciple},
            { Pattern.DependencyInversionPrinciple,                     DIP_Main.DependencyInversionPrinciple},
            /*
             * Creational patterns
             */
            /*
             * Builder Patters
             */
            { Pattern.BuilderPattern,                                   Builder_Main.BuilderPattern },
            { Pattern.BuilderPatternWithRecursiveGenerics,              Builder_Main.BuilderPatternWithRecursiveGenerics },
            { Pattern.StepwiseBuilderPattern,                           Builder_Main.StepwiseBuilderPattern },
            { Pattern.FunctionalBuilderPattern,                         Builder_Main.FunctionalBuilderPattern },
            { Pattern.FacetedBuilderPattern,                            Builder_Main.FacetedBuilderPattern },
            { Pattern.BuilderPatternCodingExercise,                     Builder_Main.BuilderPatternCodingExercise },
            /*
             * Factory Patterns
             */
            { Pattern.SimpleFactoryMethod,                              Factory_Main.SimpleFactoryMethod },
            { Pattern.AsyncFactoryMethod,                               async () => await Factory_Main.AsyncFactoryMethod() },
            { Pattern.ObjectTrackingAndBulkReplacementFactoryPattern,   Factory_Main.ObjectTrackingAndBulkReplacementFactoryPattern },
            { Pattern.InnerFactory,                                     Factory_Main.InnerFactoryPattern},
            { Pattern.AbstractFactoryPattern,                           Factory_Main.AbstractFactoryPattern},
            { Pattern.AbstractFactoryWithOCPPattern,                    Factory_Main.AbstractFactoryWithOCPPattern},
            { Pattern.FactoryCodingExercise,                            Factory_Main.FactoryCodingExercise},
            /*
             * Prototype Patterns 
             */
            { Pattern.IClonableIsBadExample,                            Prototype_Main.IClonableIsBadExample},
            { Pattern.CopyConstructorPrototypePattern,                  Prototype_Main.CopyConstructorExample},
            { Pattern.ExplicitDeepCopyPrototypePattern,                 Prototype_Main.ExplicitDeepCopy},
            { Pattern.PrototypeInheritance,                             Prototype_Main.PrototypeInheritance},
            { Pattern.SerializerPrototypePattern,                       Prototype_Main.SerializerPrototype},
            { Pattern.PrototypeCodingExercise,                          Prototype_Main.PrototypeCodingExercise},
        };

        #endregion

        public static void Main(string[] args)
        {
            // Based on the pre-set Pattern, find the action in the dictionary and invoke it
            if (_PatternDict.TryGetValue(_Pattern, out action))
            {
                action.Invoke();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(_Pattern));
            }
        }
    }
}
