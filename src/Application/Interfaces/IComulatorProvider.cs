using Domain.Enums;

namespace Application.Interfaces
{
    public interface IComulatorProvider
    {
        public IComulator Get(ComulatorType comulatorType);
    }
}
