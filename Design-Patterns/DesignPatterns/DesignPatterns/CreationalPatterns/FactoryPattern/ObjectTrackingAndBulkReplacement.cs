using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.FactoryPattern
{
    public interface ITheme
    {
        string TextColor { get; }
        string BgrColor { get; }
    }

    public class LightTheme : ITheme
    {
        public string TextColor => "Black";

        public string BgrColor => "White";
    }

    public class DarkTheme : ITheme
    {
        public string TextColor => "White";

        public string BgrColor => "Dark gray";
    }

    public class TrackingThemeFactory
    {
        private readonly List<WeakReference<ITheme>> themes = new List<WeakReference<ITheme>>();

        public ITheme CreateTheme(bool dark)
        {
            ITheme theme;

            if(dark)
                theme = new DarkTheme();
            else
                theme = new LightTheme();

            themes.Add(new WeakReference<ITheme>(theme));
            return theme;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach(var reference in themes)
                {
                    if(reference.TryGetTarget(out var theme))
                    {
                        if (theme is DarkTheme)
                            sb.Append("Dark");
                        else
                            sb.Append("Light");

                        sb.AppendLine(" Theme");
                    }
                }

                return sb.ToString();
            }
        }

    }

    // This factory allows bulk replacements. For example -> changing all the pre-constructed light themes to dark themes
    public class ReplacableThemeFactory
    {
        private readonly List<WeakReference<Ref<ITheme>>> themes = new List<WeakReference<Ref<ITheme>>>();

        private ITheme createThemeImpl(bool dark)
        {
            if(dark)
                return new DarkTheme();
            else
                return new LightTheme();
        }

        public Ref<ITheme> CreateTheme(bool dark)
        {
            var r = new Ref<ITheme>(createThemeImpl(dark));
            themes.Add(new WeakReference<Ref<ITheme>>(r));
            return r;
        }

        public void ReplaceTheme(bool dark)
        {
            foreach(var wr in themes)
            {
                if(wr.TryGetTarget(out var reference))
                {
                    reference.Value = createThemeImpl(dark);
                }
            }
        }

    }


    public class Ref<T> where T : class
    {
        public T Value;

        public Ref(T value)
        {
            Value = value;
        }
    }

}
