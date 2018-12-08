namespace OilyTools.Core.Interfaces.UseCases
{
    public interface IOutputPort<TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }

    //public interface IUseCaseRequest<TUseCaseResponse> { }

    public interface IUseCase<TUseCaseReponse>
    {
        TUseCaseReponse Execute();
    }

    public interface IUseCase<TUseCaseRequest, TUseCaseReponse>
    {
        TUseCaseReponse Execute(TUseCaseRequest request);
    }
}