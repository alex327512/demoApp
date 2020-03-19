namespace StudyingProgect.ApplicationCore.Enums
{
    public class WriteOffMethod
    {
        public enum WriteMethod
        {
            AVRG,
            FIFO,
            LIFO
        }
        public static WriteMethod GetWriteMethod(string methodName) {
            if (methodName == "Average")
            {
                return WriteMethod.AVRG;
            }
            else if (methodName == "FIFO")
            {
                return WriteMethod.FIFO;
            }
            else
            {
                return WriteMethod.LIFO;
            }
        }
    }
}
