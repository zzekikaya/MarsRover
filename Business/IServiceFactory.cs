using Business.Assembler;
using Business.Interface;

namespace Business
{
    public interface IServiceFactory
    {
        IInputService InputProviderService();

        IRoverService RoverService();

        IPlateauService PlateauService();

        IRoverCommandService MoveForwardCommandService();

        IRoverCommandService RotateLeftCommandService();

        IRoverCommandService RotateRightCommandService();

        IInputModelAssembler InputModelAssembler();
    }
}
