using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Hehao.DesignPattern.Foundation.Config
{
    public class ChapterConfigurationSelectionGroup:ConfigurationSectionGroup
    {
        private const string DelegatingItem = "delegating";
        private const string GenericsItem = "generics";

        public ChapterConfigurationSelectionGroup():base()
        {

        }

        [ConfigurationProperty(DelegatingItem,IsRequired = true)]
        public virtual DelegatingParagramConfigurationSelection Delegating
        {
            get
            {
                return base.Sections[DelegatingItem] as DelegatingParagramConfigurationSelection;
            }
        }

        public virtual GenericsParagramConfigurationSelection Generics
        {
            get
            {
                return base.Sections[GenericsItem] as GenericsParagramConfigurationSelection;
            }
        }

    }
}
