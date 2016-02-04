
namespace TDDSchulung
{
    public enum Base
    {
        HomeBase = 0,
        FirstBase = 1,
        SecondBase = 2,
        ThirdBase = 3
    }
    public static class BaseMethods
    {
        public static Base getNextBase(this Base currentBase)
        {
            switch ((int)currentBase)
            {
                default:
                    return Base.FirstBase;
                case 0:
                    return Base.FirstBase;
                case 1:
                    return Base.SecondBase;
                case 2:
                    return Base.ThirdBase;
                case 3:
                    return Base.HomeBase;
            }
        }
    }
    
}
