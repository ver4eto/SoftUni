using Logger.Contracts;
using Logger.Layouts;
using Logger.Exceptions;

namespace Logger.Factories
{
   public class LayoutFactory
    {

        public ILayout GetLayout(string type)
        {
            ILayout layout;
            if (type=="SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type=="XmlLayout")
            {
                layout = new XmlLayout();
            }
            else 
            {
                throw new InvalidTypeExceptions();
            }
            return layout;
        }
    }
}
