using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Config
{
    public abstract class ParagraphConfigurationSelectionBase:ConfigurationSection
    {
        private const string ExamplesItem = "examples";
        private const string DiagramsItem = "diagrams";

        [ConfigurationProperty(ExamplesItem,IsRequired = false)]
        public virtual ExampleConfigurationElementCollection Examples
        {
            get
            {
                return base[ExamplesItem] as ExampleConfigurationElementCollection;
            }
        }

        [ConfigurationProperty(DiagramsItem,IsRequired = false)]
        public virtual DiagramConfigurationElementCollection Diagrams
        {
            get
            {
                return base[DiagramsItem] as DiagramConfigurationElementCollection;
            }
        }
    }


    public class DelegatingParagramConfigurationSelection:ParagraphConfigurationSelectionBase
    {
        private const string PicturesItem = "pcitures";

        public virtual PictureConfigurationElementCollection Pictures
        {
            get
            {
                return base[PicturesItem] as PictureConfigurationElementCollection;
            }
        }
    }

    public class GenericsParagramConfigurationSelection:ParagraphConfigurationSelectionBase
    {

    }
}
