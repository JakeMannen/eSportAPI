using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSport
{
    public class MissingParameterException : Exception
    {
        public MissingParameterException(string message): base(message)
        {
            
        }
    }

    public class RepositoryHandlingException : Exception
    {
        public RepositoryHandlingException(string message) : base(message)
        {

        }
    }

    public class GameNotFoundException : Exception
    {
        public GameNotFoundException(string message) : base(message)
        {

        }
    }

    public class GameTypeNotFoundException : Exception
    {
        public GameTypeNotFoundException(string message) : base(message)
        {

        }
    }

    public class GameTypeAlreadyExistsException : Exception
    {
        public GameTypeAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
