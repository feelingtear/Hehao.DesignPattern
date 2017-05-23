using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Config
{
    [ConfigurationCollection(typeof(NamedConfigurationElementBase),CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class NamedConfigurationElementCollectionBase<T> : ConfigurationElementCollection where T : NamedConfigurationElementBase, new()
    {
        public T this[int index]
        {
            get
            {
                return (T)base.BaseGet(index);
            }
        }

        public new T this[string name]
        {
            get
            {
                return (T)base.BaseGet(name);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as T).Name;
        }
    }

    public class ExampleConfigurationElementCollection : NamedConfigurationElementCollectionBase<ExampleConfigurationElement>
    {

    }

    public class DiagramConfigurationElementCollection:NamedConfigurationElementCollectionBase<DiagramConfigurationElement>
    {

    }

    public class PictureConfigurationElementCollection: NamedConfigurationElementCollectionBase<PictureConfigurationElement>
    {

    }

}
