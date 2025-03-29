using Application.Interfaces;
using Domain.Enums;

namespace Infrastructure.Services
{
    public class ComulatorProvider(JustJoinItJobBoardComulator justJoinItJobBoardComulator) : IComulatorProvider
    {
        public IComulator Get(ComulatorType comulatorType) => _comulators[comulatorType];

        private readonly Dictionary<ComulatorType, IComulator> _comulators = new() {
            { ComulatorType.JustJoinIt, justJoinItJobBoardComulator }  
        };
    }
}
