using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation
{
    public interface IOrganization
    {

    }

    public abstract class UserBase<TKey,TOrganization> where TOrganization:class,IOrganization,new()
    {
        public abstract TOrganization Organization
        {
            get;
        }

        public abstract void Promotion(TOrganization newOrganization);

        delegate TOrganization OrganizationChangedHandler();
    }
}
