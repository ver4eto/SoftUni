

using Logger.Enumerations;

namespace Logger.Contracts
{
   public interface IAppender
    {

        ILayout Layout { get; }
       
        Level Level { get; }

        void Append(IError error);
    }
}
