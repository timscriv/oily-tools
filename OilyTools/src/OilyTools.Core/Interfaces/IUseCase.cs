namespace OilyTools.Core.Interfaces.UseCases
{
    public interface IUseCase<TUseCaseReponse>
    {
        TUseCaseReponse Execute();
    }

    public interface IUseCase<TUseCaseRequest, TUseCaseReponse>
    {
        TUseCaseReponse Execute(TUseCaseRequest request);
    }
}