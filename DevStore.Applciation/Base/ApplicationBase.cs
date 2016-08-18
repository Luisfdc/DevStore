using DevStore.Domain.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace DevStore.Application.Base
{
    public class ApplicationBase
    {
        private IUnitOfWork _unitOfWork;

        public void Begin()
        {
            //_unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            //_unitOfWork.Begin();
        }

        public void Commit()
        {
            //_unitOfWork.Commit();
        }

    }
}
